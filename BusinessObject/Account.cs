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
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; } 
        public int Age { get; set; }
        public bool IsEmailConfirm { get; set; }
        public virtual Role Role { get; set; } 
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<BankInformation> BankInformations { get; set; }
        public Account()
        {
            Certificates = new HashSet<Certificate>();
            BankInformations = new HashSet<BankInformation>();
        }
    }
}
