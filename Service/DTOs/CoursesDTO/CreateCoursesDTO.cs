using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.CoursesDTO
{
    public class CreateCoursesDTO
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int TeachingSlots { get; set; }
        public decimal TotalPrice { get; set; }
        public string TeachingPlace { get; set; }
    }
}
