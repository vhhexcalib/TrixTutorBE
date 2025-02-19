using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Wallet
    {
        [Key]
        [ForeignKey("Account")]
        public int TutorId { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastChangeDate { get; set; }
        public decimal LastChangeAmount { get; set; }
        public virtual Account Account { get; set; }

    }
}
