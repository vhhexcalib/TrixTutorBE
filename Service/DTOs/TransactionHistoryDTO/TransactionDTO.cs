using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TransactionHistoryDTO
{
    public class TransactionDTO
    {
        public string TransactionId { get; set; }
        public int AccountName { get; set; }
        public string PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
