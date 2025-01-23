using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.TutorDTO
{
    public class CertificateDTO
    {
        [Required(ErrorMessage = "Tệp đính kèm là bắt buộc.")]
        public List<IFormFile> AttachmentFiles { get; set; } = new List<IFormFile>();
    }
}
