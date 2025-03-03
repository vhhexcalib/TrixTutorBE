using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.OrderDTO
{
    public class CreateOrderDTO
    {
        public int TutorId { get; set; }
        public int CourseId { get; set; }

    }
}
