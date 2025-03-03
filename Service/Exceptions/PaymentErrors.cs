using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class PaymentErrors
    {
        public static Error ExistedPayment => new("Create payment", "Đơn thanh toán đã được tạo, vui long hoàn thành để tạo đơn khác.");
        public static Error FinishedPayment => new("Create payment", "Đơn thanh toán đã hoàn thành.");
    }
}
