using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.FeedBackDTO
{
    public class FeedbackDTO
    {
        public double Rating { get; set; }
        public string FeedbackContent { get; set; }
        public bool CheckingRequest { get; set; }
        public int CourseId { get; set; }
        public int FeedbackById { get; set; }
    }
}
