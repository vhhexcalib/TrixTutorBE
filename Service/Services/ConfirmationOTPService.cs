using AutoMapper;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ConfirmationOTPService : IConfirmationOTPService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ConfirmationOTPService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _unitOfWork.ConfirmationOTPRepository.CheckEmailExistAsync(email);
        }

    }
}
