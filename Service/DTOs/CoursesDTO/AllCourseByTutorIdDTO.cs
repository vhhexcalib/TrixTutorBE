using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.CoursesDTO
{
    public class AllCourseByTutorIdDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public decimal TotalPrice { get; set; }
        public int TeachingSlots { get; set; }
    }
}
