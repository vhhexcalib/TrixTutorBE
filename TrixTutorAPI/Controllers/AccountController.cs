using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.Interfaces;
using System.Net.WebSockets;

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

        [HttpPost("sign-in-accounts")]
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
        [HttpPost("create-account")]
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


    }
}
