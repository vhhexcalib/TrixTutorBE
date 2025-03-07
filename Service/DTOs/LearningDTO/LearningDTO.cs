using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.LearningDTO
{
    public class LearningDTO
    {
        public int Id { get; set; }
        public DateTime LearningDate { get; set; }
        public bool TutorAttendance { get; set; }
        public string TutorReason { get; set; }
        public int LearningTime { get; set; }
        public int SlotNumber { get; set; }
        public string TeachingPlace { get; set; }
        public string TutorName { get; set; }
        public string CourseName { get; set; }
    }
}
