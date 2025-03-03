using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TransactionHistoryDTO
{
    public class CreateTransactionDTO
    {
        public string PaymentId { get; set; }
        public string TransactionId { get; set; }
    }
}
