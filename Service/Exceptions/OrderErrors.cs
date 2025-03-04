using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class OrderErrors
    {
        public static Error ExistedOrder => new("Get Order", "Đơn thuê đã tồn tại, vui lòng tạo lại hoặc hoàn thành đơn thuê");
        public static Error CreateOrderFail => new("Create Order", "Tạo đơn thuê thất bại, không lưu vào được kho dữ liệu.");
        public static Error OrderNotFound => new("Get Order", "Đơn thuê không tồn tại, vui lòng tạo đơn thuê");
        public static Error FinishedPaymentOrder => new("Create payment", "Đơn thuê đã hoàn thành thanh toán.");
        public static Error CancelOrderFail => new("Detele Order", "Xóa đơn thuê thất bại.");


    }
}
