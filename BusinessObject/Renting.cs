using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Renting
    {
        [Key]
        public int Id { get; set; }

        // Quan hệ với tutor (gia sư)
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }
        public virtual Account Tutor { get; set; }

        public DateTime LastRentingTime { get; set; }

        // Quan hệ với student (học sinh thuê)
        [ForeignKey("Student")]
        public int LastRentingStudent { get; set; }
        public virtual Account Student { get; set; }

        // Liên kết với danh mục khóa học
        [ForeignKey("Category")]
        public int LastRentingCategoryId { get; set; }
        public virtual TutorCategory Category { get; set; }

        public bool RentingStatus { get; set; }
    }
}
