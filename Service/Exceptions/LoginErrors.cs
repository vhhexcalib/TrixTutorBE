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
        public static Error AccountIsBan => new("Login Account", "Your account is banned!!");
        public static Error InvalidAccount => new("Login Account", "Wrong email or password");
        public static Error AccountUnverified => new("Login Account", "Account have not verified by email yet");

    }
}
