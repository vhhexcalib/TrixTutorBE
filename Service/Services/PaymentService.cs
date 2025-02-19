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

namespace Service.Services
{
    public class PaymentService : IRequest<PaymentLinkDTO>, IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public string PaymentCurrency { get; set; } = string.Empty;
        public string BankInformationId { get; set; } = string.Empty;
        public decimal RequiredAmount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddMinutes(15);
        public string PaymentLanguage { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public string PaymentDestinationId { get; set; } = string.Empty;


    }
}
