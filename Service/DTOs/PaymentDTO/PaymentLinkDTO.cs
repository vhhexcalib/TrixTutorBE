using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.PaymentDTO
{
    public class PaymentLinkDTO
    {
        public string PaymentId { get; set; } = string.Empty;
        public string PaymentURL { get; set; } = string.Empty;
    }
}
