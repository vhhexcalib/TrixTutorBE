using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class TutorContactErrors
    {
        public static Error ExistedContact => new("Create contact", "Đường dẫn các tài khoản mạng xã hội của tài khoản đã tồn tại, vui lòng chỉnh sửa nếu muốn thay đổi.");
        public static Error FailCreatingContact => new("Create contact", "Tạo đường dẫn tài khoản mạng xã hội của tài khoản thất bại, vui lòng thử lại.");
    }
}
