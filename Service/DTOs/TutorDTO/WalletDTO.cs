using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TutorDTO
{
    public class WalletDTO
    {
        public decimal Balance { get; set; }
        public DateTime LastChangeDate { get; set; }
        public decimal LastChangeAmount { get; set; }
    }
}
