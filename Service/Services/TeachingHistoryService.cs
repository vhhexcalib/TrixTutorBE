﻿using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.LearningHistoryDTO;
using Service.DTOs.TeachingHistoryDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TeachingHistoryService : ITeachingHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICoursesService _courseService;

        public TeachingHistoryService(IUnitOfWork unitOfWork, IMapper mapper, ICoursesService coursesService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseService = coursesService;
        }
        public async Task<dynamic> CreateTeachingHistory(int studentId, CreateTeachingHistoryDTO createTeachingHistoryDTO)
        {
            var teachingHistory = new TeachingHistory()
            {
                StudentId = studentId,
                CourseId = createTeachingHistoryDTO.CourseId,
                TutorId = createTeachingHistoryDTO.TutorId,
                FinishDate = DateTime.Now,
                IsFinished = false
            };
            await _unitOfWork.TeachingHistoryRepository.AddAsync(teachingHistory);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(TeachingHistoryErrors.FailCreateTeachingHistory);
        }
    }
}
