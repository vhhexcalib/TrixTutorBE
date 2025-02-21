using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class BankInformationErrors
    {
        public static Error FailFindExistBankInformation=> new("Update Bank Information", "Không tìm thấy thông tin ngân hàng của người đã đăng nhập, vui lòng tạo");
        public static Error FailUpdateBankInformation => new("Update Bank Information", "Không cập nhật được thông tin ngân hàng của người đã đăng nhập, vui lòng thử lại");
        public static Error FailAddingBankInformation => new("Update Bank Information", "Không thêm mới được thông tin ngân hàng của người đã đăng nhập, vui lòng thử lại");
    }
}
