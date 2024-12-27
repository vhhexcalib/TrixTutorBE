using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.Interfaces;
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
        private readonly ITokenService _tokenService;

        public AccountController(ISystemAccountService systemAccountService, ITokenService tokenService, IAccountService accountService)
        {
            _systemAccountService = systemAccountService;
            _tokenService = tokenService;
            _accountService = accountService;
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
        [HttpPost("accounts")]
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
        [HttpPost("{email}/otp-confirmation")]
        public async Task<IActionResult> OTPConfirmation(string email, string otp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _accountService.OTPConfirmation(email, otp);
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
        [Authorize(Policy = "UserOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
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
        //// GET: api/Account/profile
        //[HttpGet("profiles")]
        //[Authorize] // Chỉ cho phép người dùng đã xác thực
        //public IActionResult GetProfilse()
        //{
        //    // Lấy thông tin người dùng từ Claims
        //    var userClaims = User.Claims;

        //    // Tạo một đối tượng để lưu thông tin người dùng
        //    var userProfile = new
        //    {
        //        AccountId = userClaims.FirstOrDefault(c => c.Type == "AccountId")?.Value,
        //        Email = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
        //        Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
        //    };

        //    return Ok(userProfile); // Trả về thông tin người dùng
        //}
    }
}
