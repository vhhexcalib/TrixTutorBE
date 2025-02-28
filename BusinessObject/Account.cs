using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public bool IsBan { get; set; }
        public bool IsEmailConfirm { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<LearningHistory> LearningHistories { get; set; } // Thêm quan hệ
        public virtual ICollection<LearningSchedule> LearningSchedules { get; set; }
        public virtual TutorInformation TutorInformation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<TeachingHistory> TeachingHistories { get; set; }
        public virtual ICollection<TeachingSchedule> TeachingSchedules { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public Account()
        {
            Feedbacks = new HashSet<Feedback>();
            LearningHistories = new HashSet<LearningHistory>(); // Khởi tạo danh sách LearningHistory
            LearningSchedules = new HashSet<LearningSchedule>(); 
            TeachingHistories = new HashSet<TeachingHistory>();
            TeachingSchedules = new HashSet<TeachingSchedule>();
            Reports = new HashSet<Report>();
            Order = new HashSet<Order>();
        }
    }

}
