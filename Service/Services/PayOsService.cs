using AutoMapper;
using BusinessObject;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.OrderDTO;
using Service.DTOs.PaymentDTO;
using Service.DTOs.TransactionHistoryDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PayOsService : IPayOsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PayOS payOS;
        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ITransactionHistoryService _transactionHistoryService;



        public PayOsService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IPaymentService paymentService, IOrderService orderService, ITransactionHistoryService transactionHistoryService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _paymentService = paymentService;
            var clientId = _configuration["PayOSSettings:ClientId"];
            var apiKey = _configuration["PayOSSettings:ApiKey"];
            var checksumKey = _configuration["PayOSSettings:ChecksumKey"];
            payOS = new PayOS(clientId, apiKey, checksumKey);
            _orderService = orderService;
            _transactionHistoryService = transactionHistoryService;
        }
        public async Task<dynamic> CreatePayment(CurrentUserObject currentUserObject, PaymentDTO paymentDTO)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderById(paymentDTO.OrderId);
            if (order == null) return Result.Failure(OrderErrors.OrderNotFound);
            var paymentId = RandomPaymentId(paymentDTO.OrderId);
            var paymentIdString = paymentId.ToString();

            var existedpayment = await _unitOfWork.PaymentRepository.GetPaymentById(paymentIdString);
            if (existedpayment != null)
            {
                return Result.Failure(PaymentErrors.ExistedPayment);
            }

            if (order.Status) return Result.Failure(OrderErrors.FinishedPaymentOrder);
            var domain = "http://localhost:3000";
            Payment newPayment = new Payment()
            {
                PaymentId = paymentIdString,
                OrderId = paymentDTO.OrderId,
                AccountId = currentUserObject.AccountId,
                Amount = order.Course.TotalPrice,
                PaymentMethod = "Pay all",
                Status = false,
                TransactionDate = DateTime.Now,
                BankCode = "",
                ResponseCode = ""
            };
            List<ItemData> items = new List<ItemData>();
            ItemData item = new ItemData(order.Course.CourseName, 1, (int)order.Course.TotalPrice);
            items.Add(item);
            PaymentData paymentData = new PaymentData(
               orderCode: paymentId,
               amount: (int)order.Course.TotalPrice,
               description: $"PaymentId:{paymentId}",
               items: items,
               cancelUrl: domain + "/paymentinfo",
               returnUrl: domain + "/paymentinfo",
               buyerName: order.Account.Name
               );
            CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
            PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(paymentId);
            CreateTransactionDTO createTransactionDTO = new CreateTransactionDTO() { PaymentId = paymentIdString, TransactionId = paymentLinkInformation.id };
            await _transactionHistoryService.CreateTransactionAsync(currentUserObject, createTransactionDTO);
            await _unitOfWork.PaymentRepository.AddAsync(newPayment);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.SuccessWithObject(createPayment.checkoutUrl) : Result.Failure(PaymentErrors.CreatePaymentFail);
        }

        public long RandomPaymentId(string order)
        {
            Random rnd = new Random();
            int newOtp = rnd.Next(100000, 999999);
            long otp = newOtp;
            return otp;
        }

        public async Task<dynamic> GetPaymentLinkInformation(string paymentId)
        {
            long paymentIdLong = long.Parse(paymentId);
            PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(paymentIdLong);
            if (paymentLinkInformation != null)
            {
                var payment = await _unitOfWork.PaymentRepository.GetPaymentById(paymentId);
                var order = await _unitOfWork.OrderRepository.GetOrderById(payment.OrderId);
                if (paymentLinkInformation.status == "Pending")
                {
                    order.Status = false;
                    await _unitOfWork.OrderRepository.UpdateAsync(order);
                }
                else if (paymentLinkInformation.status == "PAID")
                {
                    if (payment.PaymentMethod == "Pay all")
                    {
                        var adminWallet = await _unitOfWork.SystemAccountWalletRepository.GetByIdAsync(1);
                        adminWallet.Balance += payment.Amount;
                        adminWallet.LastChangeAmount = payment.Amount;
                        adminWallet.LastChangeDate = DateTime.Now;
                        order.Status = true;
                        payment.Status = true;
                        var tutorWallet = await _unitOfWork.WalletRepository.GetByIdAsync(order.TutorId);
                        tutorWallet.Balance += payment.Amount;
                        tutorWallet.LastChangeDate = DateTime.Now;
                        tutorWallet.LastChangeAmount = payment.Amount;
                        await _unitOfWork.WalletRepository.UpdateAsync(tutorWallet);
                        await _unitOfWork.PaymentRepository.UpdateAsync(payment);
                        await _unitOfWork.OrderRepository.UpdateAsync(order);
                        await _unitOfWork.SystemAccountWalletRepository.UpdateAsync(adminWallet);
                        await _unitOfWork.SaveAsync();
                        //// Lấy danh sách TeachingSlots của khóa học
                        //int teachingSlots = order.Course.TeachingSlots; // TeachingSlots là số lượng slot
                        //if (teachingSlots > 0)
                        //{
                        //    var teachingSchedules = new List<TeachingSchedule>();
                        //    var learningSchedules = new List<LearningSchedule>();

                        //    for (int i = 1; i <= teachingSlots; i++) // Lặp từ 1 đến số lượng slot
                        //    {
                        //        teachingSchedules.Add(new TeachingSchedule
                        //        {
                        //            TeachingDate = DateTime.Now.AddDays(i), // Đặt ngày học giả định
                        //            SlotNumber = i,
                        //            StudyPlace = "Online", // Hoặc một giá trị thực tế
                        //            StudentId = order.StudentId,
                        //            TutorId = order.TutorId,
                        //            CourseId = order.CourseId,
                        //            StudentAttendance = false,
                        //            StudentReason = null
                        //        });

                        //        learningSchedules.Add(new LearningSchedule
                        //        {
                        //            LearningDate = DateTime.Now.AddDays(i),
                        //            SlotNumber = i,
                        //            TeachingPlace = "Online",
                        //            StudentId = order.StudentId,
                        //            TutorId = order.TutorId,
                        //            CourseId = order.CourseId,
                        //            TutorAttendance = false,
                        //            TutorReason = null
                        //        });
                        //    }
                        //    // Thêm tất cả vào DB
                        //    await _unitOfWork.TeachingScheduleRepository.AddRangeAsync(teachingSchedules);
                        //    await _unitOfWork.LearningScheduleRepository.AddRangeAsync(learningSchedules);
                        //}
                    }
                }

                else if (paymentLinkInformation.status == "CANCELLED")
                {
                    order.Status = true;
                    order.IsCanceled = true;
                    await _unitOfWork.OrderRepository.UpdateAsync(order);
                    await _unitOfWork.PaymentRepository.DeleteAsync(payment);
                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    return Result.Failure(PaymentErrors.FailPayment);
                }
                await _unitOfWork.SaveAsync();

            }
            return Result.SuccessWithObject(paymentLinkInformation);
        }


        public async Task<dynamic> CancelPaymentLink(string orderId)
        {
            if (!long.TryParse(orderId, out long orderIdLong))
            {
                return Result.Failure(PaymentErrors.FailCancelPayment);
            }

            PaymentLinkInformation cancelledPaymentLinkInfo = await payOS.cancelPaymentLink(orderIdLong);
            return Result.Success();
        }

        public async Task<dynamic> GetOrderIdByPaymentId(string paymentId)
        {
            var paymemt = await _unitOfWork.PaymentRepository.GetAsync(x => x.PaymentId == paymentId);
            string orderId = paymemt.OrderId;
            return Result.SuccessWithObject(orderId);
        }
    }
}
