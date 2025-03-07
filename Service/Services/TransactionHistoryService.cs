using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.OrderDTO;
using Service.DTOs;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.TransactionHistoryDTO;

namespace Service.Services
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TransactionHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> CreateTransactionAsync(int accountid, string PaymentId)
        {
            var transactionId = RandomTransactionId(accountid, PaymentId);
            var existedTransactionId = await _unitOfWork.TransactionHistoryRepository.GetTransactionByPaymentId(PaymentId);
            if (existedTransactionId != null)
            {
                return Result.Failure(TransactionErrors.ExistedTransaction);
            }
            var existedPayment = await _unitOfWork.PaymentRepository.GetPaymentById(PaymentId);
            if (existedPayment == null)
            {
                return Result.Failure(PaymentErrors.ExistedPaymentNotFound);
            }          
            TransactionHistory newTransaction = new TransactionHistory() 
            {
                TransactionId = transactionId,
                PaymentId = existedPayment.PaymentId,
                AccountId = accountid,
                Amount = existedPayment.Amount,
                CreatedAt = DateTime.Now
            };           
            await _unitOfWork.TransactionHistoryRepository.AddAsync(newTransaction);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(TransactionErrors.CreateTransactionFail);
        }
        public async Task<PagedResult<TransactionDTO>> GetAllStudentOrdersAsync(CurrentUserObject currentUserObject)
        {
            var transactions = await _unitOfWork.TransactionHistoryRepository.GetTransactionsByStudentId(currentUserObject.AccountId);
            var totalItems = await _unitOfWork.TransactionHistoryRepository.CountAsync();
            return new PagedResult<TransactionDTO>
            {
                Items = _mapper.Map<IEnumerable<TransactionDTO>>(transactions),
                TotalItems = totalItems
            };
        }

        public string RandomTransactionId(int studentId, string payment)
        {
            Random rnd = new Random();
            int newOtp = rnd.Next(100000, 999999);
            string otp = newOtp.ToString();
            string student = studentId.ToString();
            return "TRS" + otp + "S" + student + "P" + payment;
        }
    }
}
