using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.CoursesDTO;
using Service.DTOs.FeedBackDTO;
using Service.DTOs.OrderDTO;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> CreateFeedBackForCourse(CurrentUserObject currentUserObject, FeedbackDTO feedbackDTO)
        {
            var student = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            if (student == null) return Result.Failure(AccountErrors.FailGetAccount);
            var learingSchedule = await _unitOfWork.LearningScheduleRepository.GetLearningScheduleByStudentId(currentUserObject.AccountId);
            if(learingSchedule.TutorReason == "" || learingSchedule.TutorReason == "Vắng") return Result.Failure(LearningScheduleErrors.AtleastLearnOneSlot);
            var feedback = new Feedback() { CourseId = feedbackDTO.CourseId, FeedbackById = feedbackDTO.FeedbackById, FeedbackContent = feedbackDTO.FeedbackContent, Rating = feedbackDTO.Rating  };
            await _unitOfWork.FeedbackRepository.AddAsync(feedback);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(FeedbackErrors.FailCreatingFeedback);
        }
        public async Task<PagedResult<GetFeedbackDTO>> GetAllCourseFeedbackAsync(CourseIdDTO courseIdDTO)
        {
            var feedbacks = await _unitOfWork.FeedbackRepository.GetAllFeedbackByCourseId(courseIdDTO.CourseId);
            var totalItems = await _unitOfWork.FeedbackRepository.CountAsync(courseIdDTO.CourseId); 
            return new PagedResult<GetFeedbackDTO>
            {
                Items = _mapper.Map<IEnumerable<GetFeedbackDTO>>(feedbacks),
                TotalItems = totalItems
            };
        }
    }
}
