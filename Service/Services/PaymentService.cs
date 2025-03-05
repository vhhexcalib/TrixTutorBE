using Microsoft.AspNetCore.Http;
using Service.DTOs.PaymentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Service.Interfaces;
using AutoMapper;
using Repository.Interfaces;
using Service.DTOs.AccountDTO;
using Service.DTOs.OrderDTO;
using Service.DTOs;

namespace Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedResult<AllPaymentDTO>> GetAllPaymentAsync()
        {
            var payments = await _unitOfWork.PaymentRepository.GetAllPayments();
            var totalItems = await _unitOfWork.PaymentRepository.CountAsync();
            return new PagedResult<AllPaymentDTO>
            {
                Items = _mapper.Map<IEnumerable<AllPaymentDTO>>(payments),
                TotalItems = totalItems
            };
        }
    }
}
