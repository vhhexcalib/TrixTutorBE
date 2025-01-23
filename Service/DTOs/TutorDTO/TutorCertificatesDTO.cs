using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TutorDTO
{
    public class TutorCertificatesDTO
    {
        public int Id { get; set; }
        public string Certification { get; set; }
        public bool Verified { get; set; }
        public DateOnly UploadedAt { get; set; }
        public int TutorId { get; set; }
    }
}
