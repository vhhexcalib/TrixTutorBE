using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TutorDTO
{
    public class TutorInformationDTO
    {
        [Required(ErrorMessage = "Thông tin hồ sơ chung là bắt buộc.")]
        public string GeneralProfile { get; set; }

        [Required(ErrorMessage = "Ngôn ngữ là bắt buộc.")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Trình độ học vấn là bắt buộc.")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Số năm kinh nghiệm là bắt buộc.")]
        public string ExperienceYear { get; set; }

        [Required(ErrorMessage = "CV là bắt buộc.")]
        public string CV { get; set; }

        [Required(ErrorMessage = "Mức lương mỗi giờ là bắt buộc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Mức lương mỗi giờ phải lớn hơn hoặc bằng 0.")]
        public decimal SalaryPerHour { get; set; }

        [Required(ErrorMessage = "Phong cách giảng dạy là bắt buộc.")]
        public string TeachingStyle { get; set; }

        [Required(ErrorMessage = "Môn học giảng dạy là bắt buộc")]
        public int TutorCategoryId { get; set; }
    }
}