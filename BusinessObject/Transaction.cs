using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Key]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
