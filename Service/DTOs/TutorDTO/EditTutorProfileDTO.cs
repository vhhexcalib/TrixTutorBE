using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TutorDTO
{
    public class EditTutorProfileDTO
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateOnly Birthday { get; set; }
        public bool IsBan { get; set; }
        public bool IsEmailConfirm { get; set; }
        public string GeneralProfile { get; set; }
        public string Language { get; set; }
        public string Degree { get; set; }
        public string ExperienceYear { get; set; }
        public int TotalTeachDay { get; set; }
        public decimal SalaryPerHour { get; set; }
        public string TeachingStyle { get; set; }
        public int TutorCategoryId { get; set; }
        public string BankName { get; set; }
        public string BankNumber { get; set; }
        public string OwnerName { get; set; }
    }
}
