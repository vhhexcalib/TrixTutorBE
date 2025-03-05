using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.PaymentDTO
{
    public class AllPaymentDTO
    {
        public string PaymentId { get; set; }
        public string OrderId { get; set; }
        public int AccountId { get; set; }
        public string TutorName { get; set; }
        public string CourseName { get; set; }
        public string StudentName { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
