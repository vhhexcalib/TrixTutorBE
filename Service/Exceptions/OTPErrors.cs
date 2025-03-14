﻿using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public static class OTPErrors
    {
        public static Error InvalidOTP => new("Confirmation OTP", "Không tìm thấy OTP, nếu không nhận được email, vui lòng kiểm tra kĩ, đợi email được gửi tới hoặc yêu cầu gửi lại OTP email sau 5 phút.");
        public static Error IncorrectOTP => new("Confirmation OTP", "Mã OTP của bạn không chính xác, vui lòng kiểm tra lại mã OTP!");

    }
}
