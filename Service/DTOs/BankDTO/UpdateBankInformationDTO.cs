using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.BankDTO
{
    public class UpdateBankInformationDTO
    {
        [Required(ErrorMessage = "Tên ngân hàng là bắt buộc.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Số tài khoản ngân hàng là bắt buộc.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Số tài khoản chỉ được chứa số.")]
        public string BankNumber { get; set; }
        [Required(ErrorMessage = "Số tài khoản ngân hàng là bắt buộc.")]
        [RegularExpression(@"^[A-Za-zÀ-ỹà-ỹ\s]+$", ErrorMessage = "Tên chủ tài khoản chỉ được chứa chữ cái, có dấu và khoảng trắng.")]
        public string OwnerName { get; set; }

    }
}
