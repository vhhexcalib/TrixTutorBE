﻿using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class ChangePasswordErrors
    {
        public static Error WrongOldPassword => new("Change Password", "Mật khẩu cũ của bạn không đúng!!");
    }
}
