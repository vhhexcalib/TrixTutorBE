using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SystemAccountWallet
    {
        [Key]
        [ForeignKey("SystemAccount")]
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastChangeDate { get; set; }
        public decimal LastChangeAmount { get; set; }

        public virtual SystemAccount SystemAccount { get; set; }
    }
}
