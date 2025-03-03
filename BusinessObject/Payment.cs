using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BankCode { get; set; }
        public string ResponseCode { get; set; }
        public virtual TransactionHistory TransactionHistory { get; set; }
    }

}
