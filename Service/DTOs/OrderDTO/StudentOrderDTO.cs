using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.OrderDTO
{
    public class StudentOrderDTO
    {
        public string OrderId { get; set; }
        public int TutorId { get; set; }
        public int CourseId { get; set; }
        public string Images { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public string TutorName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCanceled { get; set; }
        public bool Status { get; set; }
    }
}
