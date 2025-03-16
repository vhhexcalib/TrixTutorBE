using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.LearningDTO;
using Service.DTOs;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.TeachingDTO;

namespace Service.Services
{
    public class TeachingScheduleService : ITeachingScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeachingScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> AddTeachingSchedulesAsync(string orderId)
        {
            // Lấy thông tin đơn hàng
            var order = await _unitOfWork.OrderRepository.GetOrderById(orderId);
            if (order == null) return Result.Failure(OrderErrors.OrderNotFound);

            int teachingSlots = order.Course.TeachingSlots; // Số lượng slot học
            var teachingSchedules = new List<TeachingSchedule>();

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
            int teachingTime = order.Course.TeachingTimeId switch
            {
                1 => 8,
                2 => 13,
                3 => 18,
                _ => 8 // Giá trị mặc định nếu không khớp ID nào
            };

            // Tạo danh sách lịch dạy
            for (int i = 0; i < teachingSlots; i++)
            {
                DateTime teachingDate = upcomingDays[i % upcomingDays.Count];

                // Kiểm tra nếu ngày học đã qua tháng hiện tại
                if (teachingDate.Month != today.Month)
                {
                    int newMonth = teachingDate.Month + 1;
                    int newYear = teachingDate.Year;

                    // Nếu đang ở tháng 12, chuyển về tháng 1 năm sau
                    if (newMonth > 12)
                    {
                        newMonth = 1;
                        newYear += 1;
                    }

                    teachingDate = new DateTime(newYear, newMonth, 1);
                }

                teachingSchedules.Add(new TeachingSchedule
                {
                    TeachingDate = teachingDate,
                    SlotNumber = i + 1,
                    StudyPlace = order.Course.TeachingPlace,
                    StudentId = order.StudentId,
                    TutorId = order.TutorId,
                    CourseId = order.CourseId,
                    StudentAttendance = false,
                    StudentReason = "",
                    TeachingTime = teachingTime
                });
            }


            // Lưu vào DB
            await _unitOfWork.TeachingScheduleRepository.AddRangeAsync(teachingSchedules);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(LearningScheduleErrors.FailSavingSchedule);
        }

        public async Task<PagedResult<TeachingDTO>> GetAllTeachingScheduleByTutorIdAsync(CurrentUserObject currentUserObject)
        {
            var schedules = await _unitOfWork.TeachingScheduleRepository.GetTeachingSchedulesByTutorId(currentUserObject.AccountId);
            var totalItems = await _unitOfWork.TeachingScheduleRepository.CountAsync(currentUserObject.AccountId); // Đếm tổng số đơn thuê phù hợp

            // Ánh xạ danh mục sang DTO
            var categoryDtos = _mapper.Map<IEnumerable<TeachingDTO>>(schedules);

            // Trả về kết quả dưới dạng PagedResult
            return new PagedResult<TeachingDTO>
            {
                Items = _mapper.Map<IEnumerable<TeachingDTO>>(schedules),
                TotalItems = totalItems
            };
        }
        public async Task<dynamic> TakeStudentAttendance(int slotId, int flag)
        {
            var schedule = await _unitOfWork.TeachingScheduleRepository.GetByIdAsync(slotId);
            if (schedule == null) return Result.Failure(TeachingScheduleErrors.ScheduleNotFound);
            //if (schedule.StudentReason != "")
            //{
            //    return Result.Failure(TeachingScheduleErrors.StudentAlreadyTakenAttendance);
            //}
            var attendance = await _unitOfWork.LearningScheduleRepository.GetLearningScheduleToTakeAttendance(schedule.TutorId, schedule.StudentId, schedule.CourseId, schedule.SlotNumber);
            if(attendance == null)
            {
                return Result.Failure(TeachingScheduleErrors.ScheduleNotFound);
            }
            if (flag == 1)
            {
                attendance.TutorAttendance = true;
                attendance.TutorReason = "Có mặt";
            }
            else
            {
                attendance.TutorAttendance = false;
                attendance.TutorReason = "Vắng";
            }
            await _unitOfWork.LearningScheduleRepository.UpdateAsync(attendance);
            await _unitOfWork.TeachingScheduleRepository.UpdateAsync(schedule);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(TeachingScheduleErrors.FailTakingAttendance);
        }
    }
}
