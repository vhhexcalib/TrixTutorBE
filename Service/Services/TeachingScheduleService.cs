using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Repository.Repositories;
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
    public class TeachingScheduleService : ITeachingScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeachingScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> AddTeachingSchedulesAsync(IEnumerable<TeachingSchedule> schedules)
        {
            await _unitOfWork.TeachingScheduleRepository.AddRangeAsync(schedules);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(TeachingScheduleErrors.FailSavingSchedule);
            }
        }
    }
}
