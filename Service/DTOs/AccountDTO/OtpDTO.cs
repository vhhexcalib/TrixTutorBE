using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class OtpDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "OTP should be minimum 6 characters")]
        public string OTP { get; set; }
    }
}
