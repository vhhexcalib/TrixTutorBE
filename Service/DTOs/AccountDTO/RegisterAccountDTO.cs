using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class RegisterAccountDTO
    {
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_]).+$", ErrorMessage = "Mật khẩu phải có ít nhất một chữ cái viết hoa và một ký tự đặc biệt.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Họ và tên chỉ được chứa chữ và khoảng trắng.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có đúng 10 chữ số.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tuổi.")]
        [Range(1, 99, ErrorMessage = "Tuổi phải nằm trong khoảng từ 1 đến 99.")]
        public int Age { get; set; }
    }
}
