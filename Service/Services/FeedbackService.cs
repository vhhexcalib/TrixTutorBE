using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.FeedBackDTO;
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
            var feedback = new Feedback() { CourseId = feedbackDTO.CourseId, FeedbackById = feedbackDTO.FeedbackById, FeedbackContent = feedbackDTO.FeedbackContent, Rating = feedbackDTO.Rating  };
            if(feedbackDTO.CheckingRequest == true)
            await _unitOfWork.FeedbackRepository.AddAsync(feedback);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(FeedbackErrors.FailCreatingFeedback);
            }
        }
        public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbackByUserIdAsync(int userId)
        {
            var feedbacks = await _unitOfWork.FeedbackRepository.GetAllFeedbackByUserId(userId);
            return _mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
        }

    }
}
