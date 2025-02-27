using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class AllTutorDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string GeneralProfile { get; set; }
        public string Phone { get; set; }
        public DateOnly Birthday { get; set; }
        public string Language { get; set; }
        public int TotalTeachDay { get; set; }
        public decimal LowestSalaryPerHour { get; set; }
        public decimal HighestSalaryPerHour { get; set; }
        public string TutorCategoryName { get; set; }
    }
}
