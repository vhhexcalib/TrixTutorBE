using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class LearningSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime LearningDate { get; set; }
        public bool TutorAttendance { get; set; }
        public string TutorReason { get; set; }
        public int LearningTime { get; set; }
        public int SlotNumber { get; set; }
        public string TeachingPlace { get; set; }
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
