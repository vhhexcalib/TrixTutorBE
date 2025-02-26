using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        public string CourseName { get; set; }
        public string Description { get; set; }
        public int TeachingSlots { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public string TeachingPlace { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsLocked { get; set; }
        [ForeignKey("TutorInformation")]
        public int TutorId { get; set; }
        public virtual TutorInformation TutorInformation { get; set; }
        public virtual ICollection<LearningSchedule> LearningSchedules { get; set; }
        public virtual ICollection<LearningHistory> LearningHistories { get; set; } // Thêm quan hệ
        public virtual ICollection<Feedback> Feedbacks { get; set; } // Thêm quan hệ
        public virtual ICollection<TeachingHistory> TeachingHistories { get; set; }
        public virtual ICollection<TeachingSchedule> TeachingSchedules { get; set; }

        public Courses()
        {
            LearningHistories = new HashSet<LearningHistory>();
            Feedbacks = new HashSet<Feedback>();
            LearningSchedules = new HashSet<LearningSchedule>();
            TeachingHistories = new HashSet<TeachingHistory>();
            TeachingSchedules = new HashSet<TeachingSchedule>();
        }
    }

}
