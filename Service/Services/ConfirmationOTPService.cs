using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Interfaces;
using Service.Common;
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
            ConfirmationOTP? otp = await _unitOfWork.ConfirmationOTPRepository.GetOTPByEmail(email);
            if(otp == null) { return false; }
            return true;
        }
        public async Task<dynamic> GetOTPs()
        {
            var list = await _unitOfWork.ConfirmationOTPRepository.GetAllAsync();
            List<ConfirmationOTP> listCategoryDTO = new List<ConfirmationOTP>();
            foreach (var category in list)
            {
                var dto = new ConfirmationOTP
                {
                    Id = category.Id,
                    Email = category.Email,
                    CreatedAt = DateTime.Now
                };

                listCategoryDTO.Add(dto);
            }
            return Result.SuccessWithObject(listCategoryDTO);
        }
    }
}
