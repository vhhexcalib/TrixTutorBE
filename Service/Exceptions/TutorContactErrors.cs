﻿using Service.Common;
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
        public static Error NotFoundContact => new("Get contact", "Đường dẫn các tài khoản mạng xã hội của tài khoản chưa tồn tại, vui lòng thêm mới.");
        public static Error FailUpdatingContact => new("Update contact", "Cập nhật đường dẫn tài khoản mạng xã hội của tài khoản thất bại, vui lòng thử lại.");
    }
}
