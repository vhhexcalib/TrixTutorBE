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
        public static Error InvalidOTP => new("Confirmation OTP", "Không tìm thấy OTP, vui lòng kiểm tra lại email của bạn hoặc yêu cầu gửi lại OTP.");
        public static Error IncorrectOTP => new("Confirmation OTP", "Mã OTP của bạn không chính xác, vui lòng kiểm tra lại mã OTP!");

    }
}
