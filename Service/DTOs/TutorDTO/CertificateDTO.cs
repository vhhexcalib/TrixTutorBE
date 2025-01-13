using BusinessObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TutorDTO
{
    public class CertificateDTO
    {
        public IFormFile AttachmentFile { get; set; } = null!;
        public string Certification { get; set; }
    }
}
