using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Rating { get; set; } // Đổi từ string -> double
        public string ReportContent { get; set; }
        public bool AdminChecked { get; set; }
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; }
        public virtual TutorInformation TutorInformation { get; set; }
        [ForeignKey("Account")]
        public int ReportById { get; set; }
        public virtual Account Account { get; set; }
    }
}
