using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.OrderDTO
{
    public class OrderDetailDTO
    {
        public string OrderId { get; set; }
        public string TutorName { get; set; }
        public string CourseName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public int TotalSlots { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
