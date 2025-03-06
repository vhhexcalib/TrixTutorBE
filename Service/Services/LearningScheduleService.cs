using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<dynamic> AddLearningSchedulesAsync(int totalSlots, int teachingDate, int teachingTime)
        {
            // Lấy danh sách TeachingSlots của khóa học
            int teachingSlots = order.Course.TeachingSlots; // TeachingSlots là số lượng slot
            if (teachingSlots > 0)
            {
                var teachingSchedules = new List<TeachingSchedule>();
                var learningSchedules = new List<LearningSchedule>();

                for (int i = 1; i <= teachingSlots; i++) // Lặp từ 1 đến số lượng slot
                {
                    teachingSchedules.Add(new TeachingSchedule
                    {
                        TeachingDate = DateTime.Now.AddDays(i), // Đặt ngày học giả định
                        SlotNumber = i,
                        StudyPlace = "Online", // Hoặc một giá trị thực tế
                        StudentId = order.StudentId,
                        TutorId = order.TutorId,
                        CourseId = order.CourseId,
                        StudentAttendance = false,
                        StudentReason = null
                    });

                    learningSchedules.Add(new LearningSchedule
                    {
                        LearningDate = DateTime.Now.AddDays(i),
                        SlotNumber = i,
                        TeachingPlace = "Online",
                        StudentId = order.StudentId,
                        TutorId = order.TutorId,
                        CourseId = order.CourseId,
                        TutorAttendance = false,
                        TutorReason = null
                    });
                }
                // Thêm tất cả vào DB
                await _unitOfWork.TeachingScheduleRepository.AddRangeAsync(teachingSchedules);
                await _unitOfWork.LearningScheduleRepository.AddRangeAsync(learningSchedules);
            }
            await _unitOfWork.LearningScheduleRepository.AddRangeAsync(schedules);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(LearningScheduleErrors.FailSavingSchedule);
            }
        }
    }
}
