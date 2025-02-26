﻿using AutoMapper;
using BusinessObject;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;
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
    public class PayOsService : IPayOsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PayOS payOS;
        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;

        public PayOsService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _paymentService = paymentService;
            var clientId = _configuration["PayOSSettings:ClientId"];
            var apiKey = _configuration["PayOSSettings:ApiKey"];
            var checksumKey = _configuration["PayOSSettings:ChecksumKey"];
            payOS = new PayOS(clientId, apiKey, checksumKey);
        }
        //public async Task<dynamic> CreatePayment(int orderId)
        //{
        //    var payment = await _unitOfWork.PaymentRepository.
        //    if (payment != null && payment.Any())
        //    {
        //        return Result.Failure(payment.PaymentError);
        //    }
        //    var orderNow = await _unitOfWork.OrderRepository.GetAsync(x => x.OrderId == orderId, includeProperties: "Account,StatusOrder");
        //    if (orderNow == null)
        //        return Result.Failure(OrderErrors.OrderIsNull);
        //    if (orderNow.IsRentalOrder) return Result.Failure(PaymentErrors.WrongPayment);
        //    var odList = await _unitOfWork.OrderDetailRepository.GetAllAsync(x => x.OrderId == orderNow.OrderId, includeProperties: "Toy", 1, 100);
        //    var odSaleList = _mapper.Map<List<ODSaleDTO>>(odList);
        //    List<ItemData> items = new List<ItemData>();
        //    foreach (var odSale in odSaleList)
        //    {
        //        ItemData item = new ItemData(odSale.ToyName, odSale.Quantity, (int)odSale.Price);
        //        items.Add(item);
        //    }
        //    var domain = "http://localhost:3000";
        //    Payment payment = new Payment()
        //    {
        //        OrderId = orderId,
        //        AccountId = orderNow.Account.AccountId,
        //        Amount = orderNow.FinalMoney,
        //        PaymentMethod = "Pay all",
        //        Status = 0,
        //        TransactionId = "o",
        //        TransactionDate = DateTime.Now,
        //        BankCode = "",
        //        ResponseCode = ""
        //    };
        //    var save = await _unitOfWork.PaymentRepository.AddAsync(payment);
        //    await _unitOfWork.SaveAsync();

        //    PaymentData paymentData = new PaymentData(
        //        orderCode: payment.PaymentId,
        //        amount: (int)payment.Amount,
        //        description: $"Order sale paymentId:{payment.PaymentId}",
        //        items: items,
        //        cancelUrl: domain + "/paymentinfo",
        //        returnUrl: domain + "/paymentinfo",

        //        buyerName: orderNow.Account.AccountName
        //        );
        //    try
        //    {
        //        CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
        //        PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(payment.PaymentId);
        //        payment.TransactionId = paymentLinkInformation.id;      //update lai transactiondId
        //        await _unitOfWork.PaymentRepository.UpdateAsync(payment);
        //        await _unitOfWork.SaveAsync();
        //        return Result.SuccessWithObject(createPayment.checkoutUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Failure(PaymentErrors.PaymentError);
        //    }
        //}

        //public async Task<dynamic> CreatePaymentLinkForRent(int orderId)
        //{
        //    var paymentSale = await _unitOfWork.PaymentRepository.GetAllAsync(x => x.OrderId == orderId);
        //    if (paymentSale != null && paymentSale.Any())
        //    {
        //        return Result.Failure(PaymentErrors.PaymentError);
        //    }
        //    var orderNow = await _unitOfWork.OrderRepository.GetAsync(x => x.OrderId == orderId, includeProperties: "Account,StatusOrder");
        //    if (orderNow == null)
        //        return Result.Failure(OrderErrors.OrderIsNull);
        //    if (!orderNow.IsRentalOrder) return Result.Failure(PaymentErrors.WrongPayment);
        //    var odList = await _unitOfWork.OrderDetailRepository.GetAllAsync(x => x.OrderId == orderNow.OrderId, includeProperties: "Toy", 1, 100);
        //    var odRentList = _mapper.Map<List<ODRentDTO>>(odList);
        //    List<ItemData> items = new List<ItemData>();
        //    foreach (var odSale in odRentList)
        //    {
        //        ItemData item = new ItemData(odSale.ToyName, odSale.Quantity, (int)odSale.RentalPrice);
        //        items.Add(item);
        //    }
        //    var domain = "http://localhost:3000";

        //    Payment payment1 = new Payment()
        //    {
        //        OrderId = orderId,
        //        AccountId = orderNow.Account.AccountId,
        //        Amount = orderNow.FinalMoney / 2,
        //        PaymentMethod = "Pay 1",
        //        Status = 0,
        //        TransactionId = "o",
        //        TransactionDate = DateTime.Now,
        //        BankCode = "",
        //        ResponseCode = ""
        //    };
        //    decimal last = orderNow.FinalMoney - payment1.Amount;
        //    var save = await _unitOfWork.PaymentRepository.AddAsync(payment1);
        //    await _unitOfWork.SaveAsync();

        //    PaymentData paymentData = new PaymentData(
        //        orderCode: payment1.PaymentId,
        //        amount: (int)payment1.Amount,
        //        description: $"Order rent1 paymentId:{payment1.PaymentId}",
        //        items: items,
        //        cancelUrl: domain + "/paymentinfo",
        //        returnUrl: domain + "/paymentinfo",

        //        buyerName: orderNow.Account.AccountName
        //        );
        //    try
        //    {
        //        CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
        //        PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(payment1.PaymentId);
        //        payment1.TransactionId = paymentLinkInformation.id;
        //        await _unitOfWork.PaymentRepository.UpdateAsync(payment1);
        //        await _unitOfWork.DepositOrderRepository.CreateDepositOrder(orderNow, "000", "bank"); // dat coc
        //        await _unitOfWork.SaveAsync();
        //        Payment payment2 = new Payment()
        //        {
        //            OrderId = orderId,
        //            AccountId = orderNow.Account.AccountId,
        //            Amount = last,
        //            PaymentMethod = "Pay 2",
        //            Status = 0,
        //            TransactionId = "o",
        //            TransactionDate = DateTime.Now,
        //            BankCode = "",
        //            ResponseCode = ""
        //        };
        //        var save2 = await _unitOfWork.PaymentRepository.AddAsync(payment2);
        //        await _unitOfWork.SaveAsync();
        //        return Result.SuccessWithObject(createPayment.checkoutUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Failure(PaymentErrors.PaymentError);
        //    }
        //}

        //public async Task<dynamic> CreatePaymentLinkForRent2(int orderId)
        //{
        //    var domain = "http://localhost:3000";
        //    List<ItemData> items = new List<ItemData>();
        //    Payment payment2 = await _unitOfWork.PaymentRepository.GetAsync(x => x.OrderId == orderId && x.PaymentMethod == "Pay 2" && x.TransactionId == "o");
        //    if (payment2 == null)
        //    {
        //        return Result.Failure(PaymentErrors.PaymentError);
        //    }
        //    PaymentData paymentData = new PaymentData(
        //        orderCode: payment2.PaymentId,
        //        amount: (int)payment2.Amount,
        //        description: $"Order rent2 paymentId:{payment2.PaymentId}",
        //        items: items,
        //        cancelUrl: domain + "/paymentinfo",
        //        returnUrl: domain + "/paymentinfo"
        //        );
        //    try
        //    {
        //        CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
        //        PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(payment2.PaymentId);
        //        payment2.TransactionId = paymentLinkInformation.id;
        //        payment2.TransactionDate = DateTime.Now;
        //        await _unitOfWork.PaymentRepository.UpdateAsync(payment2);
        //        await _unitOfWork.SaveAsync();
        //        return Result.SuccessWithObject(createPayment.checkoutUrl);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Failure(PaymentErrors.PaymentError);
        //    }
        //}

        //public async Task<dynamic> GetPaymentLinkInformation(int paymentId)
        //{
        //    PaymentLinkInformation paymentLinkInformation = await payOS.getPaymentLinkInformation(paymentId);
        //    if (paymentLinkInformation != null)
        //    {
        //        var payment = await _unitOfWork.PaymentRepository.GetAsync(x => x.PaymentId == paymentId);
        //        int orderId = payment.OrderId;
        //        int status = 0;
        //        if (paymentLinkInformation.status == "Pending")
        //        {
        //            status = 0; // chua thanh toan
        //            await _unitOfWork.OrderRepository.UpdateOrderStatus(orderId, 1);
        //        }
        //        else if (paymentLinkInformation.status == "PAID")
        //        {
        //            status = 1; // thanh toan xong
        //            if (payment.PaymentMethod == "Pay 1" || payment.PaymentMethod == "Pay all")
        //            {
        //                await _unitOfWork.OrderRepository.UpdateOrderStatus(orderId, 2);
        //            }
        //        }
        //        else if (paymentLinkInformation.status == "CANCELLED")
        //        {
        //            status = 2; // huy don
        //            await _unitOfWork.OrderRepository.UpdateOrderStatus(orderId, 9);
        //        }
        //        else
        //        {
        //            status = 3; // ko xd dc
        //            await _unitOfWork.OrderRepository.UpdateOrderStatus(orderId, 1);
        //        }
        //        payment.Status = status;
        //        await _unitOfWork.PaymentRepository.UpdatePayment(payment); // update lai status trong payment
        //        await _unitOfWork.SaveAsync();
        //    }
        //    return Result.SuccessWithObject(paymentLinkInformation);
        //}


        //public async Task<dynamic> CancelPaymentLink(int orderId)
        //{
        //    PaymentLinkInformation cancelledPaymentLinkInfo = await payOS.cancelPaymentLink(orderId);
        //    return Result.Success();
        //}

        //public async Task<dynamic> GetAllPaymentForStaff(int status)
        //{
        //    var payments = await _unitOfWork.PaymentRepository.GetPaymentForStaff(status);

        //    return Result.SuccessWithObject(payments);
        //}

        //public async Task<dynamic> GetOrderIdByPaymentId(int paymentId)
        //{
        //    var paymemt = await _unitOfWork.PaymentRepository.GetAsync(x => x.PaymentId == paymentId);
        //    int orderId = paymemt.OrderId;
        //    return Result.SuccessWithObject(orderId);
        //}
    }
}
