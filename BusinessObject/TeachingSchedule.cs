using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TeachingSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TeachingDate { get; set; }
        public bool StudentAttendance { get; set; }
        public string StudentReason { get; set; }
        public int SlotNumber { get; set; }
        public string StudyPlace { get; set; }
        [ForeignKey("Account")]
        public int StudentId { get; set; }
        public virtual Account Account { get; set; }
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; }
        public virtual TutorInformation TutorInformation { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Courses Course { get; set; }
    }
}
