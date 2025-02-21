using System;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.TutorContactDTO
{
    public class CreateContactDTO
    {
        [Required(ErrorMessage = "Facebook URL là bắt buộc.")]
        [Url(ErrorMessage = "Facebook URL không hợp lệ.")]
        public string FacebookURL { get; set; }

        [Required(ErrorMessage = "Instagram URL là bắt buộc.")]
        [Url(ErrorMessage = "Instagram URL không hợp lệ.")]
        public string InstagramURL { get; set; }

        [Required(ErrorMessage = "X (Twitter) URL là bắt buộc.")]
        [Url(ErrorMessage = "X (Twitter) URL không hợp lệ.")]
        public string XURL { get; set; }

        [Required(ErrorMessage = "LinkedIn URL là bắt buộc.")]
        [Url(ErrorMessage = "LinkedIn URL không hợp lệ.")]
        public string LinkedIn { get; set; }
    }
}
