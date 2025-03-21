﻿using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class AccountErrors
    {
        public static Error FailGetProfile => new("Get profile", "Thông tin tài khoản không tồn tại vui lòng chọn tài khoản khác.");
        public static Error FailGetAccount => new("Get Account", "Tài khoản không tồn tại vui lòng chọn tài khoản khác.");
        public static Error FailUpdateProfile => new("Update profile", "Thông tin tài khoản cập nhật thất bại.");

    }
}
