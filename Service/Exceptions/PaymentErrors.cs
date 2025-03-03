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
        public static Error CreatePaymentFail => new("Create Payment", "Tạo thanh toán thất bại, không lưu vào được kho dữ liệu.");
        public static Error ExistedPaymentNotFound => new("Create Transaction", "Đơn thanh toán không tồn tại, vui lòng tạo một thanh toán.");
        public static Error FailPayment => new("Update Payment", "Đơn thanh toán không thành công, vui lòng thử lại");
        public static Error FailCancelPayment => new("Cancel Payment", "Hủy đơn thanh toán không thành công, vui lòng thử lại");

    }
}
