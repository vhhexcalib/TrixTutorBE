using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TutorInformation
    {
        [Key]
        [ForeignKey("Account")]
        public int TutorId { get; set; }
        public virtual Account Account { get; set; }
        public string GeneralProfile { get; set; }
        public string Language { get; set; }
        public string Degree { get; set; }
        public string ExperienceYear { get; set; }
        public int TotalTeachDay { get; set; }
        public string CV { get; set; }
        public decimal LowestSalaryPerHour { get; set; }
        public decimal HighestSalaryPerHour { get; set; }
        public string TeachingStyle { get; set; }


        [ForeignKey("TutorCategory")]
        public int TutorCategoryId { get; set; }
        public virtual BankInformation BankInformation { get; set; }
        public virtual TutorCategory TutorCategory { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual TutorContact TutorContact { get; set; }
        public TutorInformation()
        {
            Certificates = new HashSet<Certificate>();
        }
    }
}
