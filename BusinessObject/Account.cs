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

        // Danh sách feedbacks mà tài khoản đã nhận
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        // Thông tin gia sư nếu tài khoản này là tutor
        public virtual TutorInformation TutorInformation { get; set; }

        // Danh sách các giao dịch thanh toán
        public virtual ICollection<Payment> Payments { get; set; }

        // Danh sách lịch sử giao dịch
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }

        // Ví của tài khoản
        public virtual Wallet Wallet { get; set; }

        // **Quan hệ với bảng Renting**

        // Danh sách các lần được thuê nếu tài khoản là tutor
        public virtual ICollection<Renting> RentingsAsTutor { get; set; }

        // Danh sách các lần đi thuê nếu tài khoản là student
        public virtual ICollection<Renting> RentingsAsStudent { get; set; }

        public Account()
        {
            Feedbacks = new HashSet<Feedback>();
            RentingsAsTutor = new HashSet<Renting>();
            RentingsAsStudent = new HashSet<Renting>();
        }
    }
}
