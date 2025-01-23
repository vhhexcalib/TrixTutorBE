using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public static class LoginErrors
    {
        public static Error AccountIsBan => new("Login Account", "Tài khoản của bạn bị khóa!!");
        public static Error InvalidAccount => new("Login Account", "Sai email hoặc mật khẩu");
        public static Error AccountUnverified => new("Login Account", "Tài khoản chưa được xác thực email");

    }
}
