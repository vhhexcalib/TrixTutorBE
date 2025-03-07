using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using Service.Interfaces;
using Service.Services;
using System.Net.WebSockets;
using System.Security.Claims;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISystemAccountService _systemAccountService;
        private readonly IAccountService _accountService;
        private readonly ITutorInformationService _tutorInformationService;
        private readonly ITokenService _tokenService;

        public AccountController(ISystemAccountService systemAccountService, ITokenService tokenService, IAccountService accountService, ITutorInformationService tutorInformationService)
        {
            _systemAccountService = systemAccountService;
            _tokenService = tokenService;
            _accountService = accountService;
            _tutorInformationService = tutorInformationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _systemAccountService.LoginAsync(loginDTO);
                if (!result.IsSuccess)
                {
                    var result2 = await _accountService.LoginAsync(loginDTO);
                    if (result2.IsSuccess)
                    {
                        return Ok(result2);
                    }
                    return BadRequest(result2);
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("account")]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterAccountDTO registerAccountDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var result = await _accountService.CreateAccount(registerAccountDTO);
                if(result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("otp-confirmation")]
        public async Task<IActionResult> OTPConfirmation([FromBody] OtpDTO otp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _accountService.OTPConfirmation(otp.Email, otp.OTP);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "UserOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}/password")]
        public async Task<IActionResult> ChangePassword(PasswordDTO password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _accountService.ChangePassword(password, currentUserObject);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "StudentOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] EditProfileStudentDTO profileDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _accountService.UpdateProfile(currentUserObject, profileDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "UserOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _accountService.GetProfile(currentUserObject);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}/tutor-student")]
        public async Task<IActionResult> GetProfileById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _accountService.GetProfileByIdBasedOnRole(id);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "SystemAccountOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("accounts")]
        public async Task<IActionResult> GetAllAccounts([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] bool sortByBirthdayAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _accountService.GetAllAccountsAsync(page, size, search, sortByBirthdayAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
       
    }
}
