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
        public static Error InvalidOTP => new("Confirmation OTP", "OTP not found, please check your email again or request to resent otp");
        public static Error IncorrectOTP => new("Confirmation OTP", "Your OTP code is incorrect, please double check your OTP!");

    }
}
