using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.LearningHistoryDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LearningHistoryService : ILearningHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoursesService _courseService;

        public LearningHistoryService(IUnitOfWork unitOfWork, IMapper mapper, ICoursesService coursesService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseService = coursesService;
        }
        public async Task<dynamic> CreateLearningHistory(int studentId, CreateLearningHistoryDTO createLearningHistoryDTO)
        {
            var learningHistory = new LearningHistory()
            {
                StudentId = studentId,
                CourseId = createLearningHistoryDTO.CourseId,
                TutorId = createLearningHistoryDTO.TutorId,
                FinishDate = DateTime.Now,
                IsFinished = false
            };
            await _unitOfWork.LearningHistoryRepository.AddAsync(learningHistory);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(LearningHistoryErrors.FailCreateLearningHistory);
        }
    }
}
