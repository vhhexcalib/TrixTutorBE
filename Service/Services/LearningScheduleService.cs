using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.TutorDTO;
using Service.DTOs;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.AccountDTO;
using Service.DTOs.OrderDTO;
using Service.DTOs.LearningDTO;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Service.Services
{
    public class LearningScheduleService : ILearningScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LearningScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> AddLearningSchedulesAsync(string orderId)
        {
            // Lấy thông tin đơn hàng
            var order = await _unitOfWork.OrderRepository.GetOrderById(orderId);
            if (order == null) return Result.Failure(OrderErrors.OrderNotFound);

            int teachingSlots = order.Course.TeachingSlots; // Số lượng slot học
            var learningSchedules = new List<LearningSchedule>();

            // Xác định danh sách các ngày trong tuần theo TeachingDateId
            var teachingDays = order.Course.TeachingDateId switch
            {
                1 => new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday },
                2 => new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday },
                3 => new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Saturday },
                _ => new List<DayOfWeek> { DayOfWeek.Monday } // Mặc định nếu không khớp
            };

            // Tìm danh sách ngày hợp lệ trong tương lai
            DateTime today = DateTime.Now;
            var upcomingDays = Enumerable.Range(0, 30) // Kiểm tra trong 30 ngày tới
                .Select(d => today.AddDays(d))
                .Where(d => teachingDays.Contains(d.DayOfWeek))
                .Take(teachingSlots) // Lấy đúng số lượng slot cần thiết
                .ToList();

            // Đặt giờ học theo TeachingTimeId
            int learningTime = order.Course.TeachingTimeId switch
            {
                1 => 8,
                2 => 13,
                3 => 18,
                _ => 8 // Giá trị mặc định nếu không khớp ID nào
            };

            // Tạo danh sách lịch học
            for (int i = 0; i < teachingSlots; i++)
            {
                DateTime learningDate = upcomingDays[i % upcomingDays.Count]; // Quay lại từ đầu nếu slot nhiều hơn số ngày hợp lệ

                learningSchedules.Add(new LearningSchedule
                {
                    LearningDate = learningDate,
                    SlotNumber = i + 1,
                    TeachingPlace = order.Course.TeachingPlace,
                    StudentId = order.StudentId,
                    TutorId = order.TutorId,
                    CourseId = order.CourseId,
                    TutorAttendance = false,
                    TutorReason = "",
                    LearningTime = learningTime
                });
            }

            // Lưu vào DB
            await _unitOfWork.LearningScheduleRepository.AddRangeAsync(learningSchedules);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(LearningScheduleErrors.FailSavingSchedule);
        }
        public async Task<PagedResult<LearningDTO>> GetAllLearningScheduleByStudentIdAsync(CurrentUserObject currentUserObject)
        {
            var schedules = await _unitOfWork.LearningScheduleRepository.GetLearningSchedulesByStudentId(currentUserObject.AccountId);
            var totalItems = await _unitOfWork.LearningScheduleRepository.CountAsync(); // Đếm tổng số đơn thuê phù hợp

            // Ánh xạ danh mục sang DTO
            var categoryDtos = _mapper.Map<IEnumerable<LearningDTO>>(schedules);

            // Trả về kết quả dưới dạng PagedResult
            return new PagedResult<LearningDTO>
            {
                Items = _mapper.Map<IEnumerable<LearningDTO>>(schedules),
                TotalItems = totalItems
            };
        }
        public async Task<dynamic> TakeTutorAttendance (int slotId, int flag)
        {
            var schedule = await _unitOfWork.LearningScheduleRepository.GetByIdAsync(slotId);
            if (schedule == null) return Result.Failure(LearningScheduleErrors.ScheduleNotFound);
            if (schedule.TutorReason != "")
            {
                return Result.Failure(LearningScheduleErrors.TutorAlreadyTakenAttendance);
            }
            if (flag == 1)
            {
                schedule.TutorAttendance = true;
                schedule.TutorReason = "Có mặt";
                var tutor = await _unitOfWork.TutorInformationRepository.GetByIdAsync(schedule.TutorId);
                tutor.TotalTeachDay++;
                await _unitOfWork.TutorInformationRepository.UpdateAsync(tutor);
            }
            else
            {
                schedule.TutorAttendance = false;
                schedule.TutorReason = "Vắng";
            }
            await _unitOfWork.LearningScheduleRepository.UpdateAsync(schedule);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(LearningScheduleErrors.FailTakingAttendance);
        }
    }
}
