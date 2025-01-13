using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.TutorDTO
{
    public class CertificateDTO
    {
        [Required(ErrorMessage = "Attachment file is required.")]
        public List<IFormFile> AttachmentFiles { get; set; } = new List<IFormFile>();
    }
}
