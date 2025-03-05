using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; }
        public virtual TutorInformation TutorInformation { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Courses Course { get; set; }
        public bool IsCanceled { get; set; }
        [ForeignKey("Account")]
        public int StudentId { get; set; }
        public virtual Account Account { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }

    }
}
