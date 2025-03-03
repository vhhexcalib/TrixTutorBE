using Service.DTOs.AccountDTO;
using Service.DTOs.PaymentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPayOsService
    {
        Task<dynamic> CreatePayment(CurrentUserObject currentUserObject, PaymentDTO paymentDTO);
        Task<dynamic> GetPaymentLinkInformation(string orderId);
        Task<dynamic> CancelPaymentLink(string orderId);
        Task<dynamic> GetOrderIdByPaymentId(string paymentId);
    }
}
