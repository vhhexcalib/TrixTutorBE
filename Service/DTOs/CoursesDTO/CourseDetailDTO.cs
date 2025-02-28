using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.CoursesDTO
{
    public class CourseDetailDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int TeachingSlots { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public string Images { get; set; }
        public string TeachingPlace { get; set; }
        public string TutorName { get; set; }
        public string TeachingDates { get; set; }
        public string TeachingTimes { get; set; }
    }
}
