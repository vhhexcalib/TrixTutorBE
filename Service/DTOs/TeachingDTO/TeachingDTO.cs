using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TeachingDTO
{
    public class TeachingDTO
    {
        public int Id { get; set; }
        public DateTime TeachingDate { get; set; }
        public bool StudentAttendance { get; set; }
        public string StudentReason { get; set; }
        public int SlotNumber { get; set; }
        public int TeachingTime { get; set; }
        public string StudyPlace { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
    }
}
