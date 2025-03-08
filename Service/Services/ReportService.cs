using AutoMapper;
using Repository.Interfaces;
using Service.DTOs.AccountDTO;
using Service.DTOs.ReportDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //public async Task<dynamic> CreateReport(CurrentUserObject currentUserObject, CreateReportDTO createReportDTO)
        //{

        //}
    }
}
