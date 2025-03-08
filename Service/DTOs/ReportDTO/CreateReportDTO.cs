using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.ReportDTO
{
    public class CreateReportDTO
    {
        public double Rating { get; set; }
        public string ReportContent { get; set; }
        public bool AdminChecked { get; set; }
        public int TutorId { get; set; }
        public int ReportById { get; set; }
    }
}
 