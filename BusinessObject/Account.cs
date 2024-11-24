using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public int Age { get; set; }
        public bool IsEmailConfirm { get; set; }
        public virtual Role Role { get; set; }
        public virtual Certificate Certificates { get; set; }
        public virtual BankInformation BankInformation { get; set; }
    }
}
