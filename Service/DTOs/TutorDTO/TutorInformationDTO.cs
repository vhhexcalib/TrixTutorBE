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
        [Required]
        public string GeneralProfile { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string ExperienceYear { get; set; }
        [Required]
        public int TotalTeachDay { get; set; }
        [Required]
        public string CV { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "LowestSalaryPerHour must be greater than or equal to 0.")]
        public decimal LowestSalaryPerHour { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "HighestSalaryPerHour must be greater than or equal to 0.")]
        public decimal HighestSalaryPerHour { get; set; }
        [Required]
        public string TeachingStyle { get; set; }
    }
}
