using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Rating { get; set; } // Đổi từ string -> double
        public string FeedbackContent { get; set; }
        public bool CheckingRequest { get; set; } // Đổi tên tránh sai chính tả
        public bool AdminChecked { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Courses Course { get; set; }
        [ForeignKey("Account")]
        public int FeedbackById { get; set; }
        public virtual Account Account { get; set; }
    }

}
