using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TransactionHistory
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey("Payment")]
        public string PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
