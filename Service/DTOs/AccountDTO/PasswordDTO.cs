﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class PasswordDTO
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ.")]
        [MinLength(6, ErrorMessage = "Mật khẩu cũ phải có ít nhất 6 ký tự.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [MinLength(6, ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự.")]
        public string NewPassword { get; set; }
    }
}
