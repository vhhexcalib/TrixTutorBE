using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.FeedBackDTO
{
    public class GetFeedbackDTO
    {
        public double Rating { get; set; }
        public string FeedbackContent { get; set; }
        public int CourseName { get; set; }
        public int FeedbackByName { get; set; }
    }
}
