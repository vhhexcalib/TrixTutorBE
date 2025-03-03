using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class TransactionErrors
    {
        public static Error ExistedTransaction => new("Create Transaction", "Giao dịch đã tồn tại, vui lòng hoàn thành giao dịch.");
        public static Error CreateTransactionFail => new("Create Transaction", "Tạo giao dịch thất bại, không lưu vào được kho dữ liệu.");
        public static Error TransactionNotFound => new("Create Order", "Giao dịch không tồn tại, vui lòng tạo giao dịch");
        public static Error FinishedTransaction => new("Create payment", "Đơn thuê đã hoàn thành thanh toán.");
    }
}
