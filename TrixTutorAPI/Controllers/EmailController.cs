using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
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
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;


        public EmailController(IEmailService emailService, IConfirmationOTPService confirmationOTPService, IUnitOfWork unitOfWork)
        {
            _emailService = emailService;
            _confirmationOTPService = confirmationOTPService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("resend-confirmation")]
        public async Task<IActionResult> SendEmail(string receptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var account = await _unitOfWork.AccountRepository.GetAccountByEmail(receptor);
                if (account != null)
                {
                    var flag = await _confirmationOTPService.CheckEmailExistAsync(receptor);
                    if (flag) return BadRequest("The OTP is still valid, please enter the OTP");
                    else
                    {
                        await _emailService.SendEmail(receptor);
                        return Ok("The OTP email has been resent");
                    }
                }
                else return BadRequest("The email has not been created as an account, please create an account");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        //[HttpGet("otps")]
        //public async Task<IActionResult> GetOTPs()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _confirmationOTPService.GetOTPs();
        //        if (result.IsSuccess) return Ok(result);
        //        return BadRequest(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
    }
}
