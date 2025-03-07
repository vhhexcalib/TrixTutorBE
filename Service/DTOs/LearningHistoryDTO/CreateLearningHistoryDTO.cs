using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.LearningHistoryDTO
{
    public class CreateLearningHistoryDTO
    {
        public int TutorId { get; set; }
        public int CourseId { get; set; }
        public bool IsFinished { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
