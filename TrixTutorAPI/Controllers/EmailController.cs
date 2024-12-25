using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.Interfaces;
using Service.Services;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IConfirmationOTPService _confirmationOTPService;

        public EmailController(IEmailService emailService, IConfirmationOTPService confirmationOTPService)
        {
            _emailService = emailService;
            _confirmationOTPService = confirmationOTPService;
        }
        [HttpPost("resend-confirmation-email")]
        public async Task<IActionResult> SendEmail(string receptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var existedOTP = _confirmationOTPService.CheckEmailExistAsync(receptor);
                if (existedOTP != null) return BadRequest("The OTP is still valid, please enter the OTP");
                else
                {
                    await _emailService.SendEmail(receptor);
                    return Ok("The OTP email has been resent");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
