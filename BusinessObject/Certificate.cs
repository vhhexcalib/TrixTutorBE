using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [Required]
        [StringLength(200)]
        public string Certification { get; set; }
        public bool Verified { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Account Account { get; set; }
    }
}
