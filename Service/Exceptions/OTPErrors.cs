using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public static class OTPErrors
    {
        public static Error ValidOTP => new("Confirmation OTP", "Your OTP code is still valid, please check your email!");
        public static Error IncorrectOTP => new("Confirmation OTP", "Your OTP code is incorrect, please double check your OTP!");

    }
}
