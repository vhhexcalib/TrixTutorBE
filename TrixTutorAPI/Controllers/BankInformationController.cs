using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.BankDTO;
using Service.Interfaces;
using Service.Services;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankInformationController : ControllerBase
    {
        private readonly IBankInformationService _bankInformationService;
        private readonly ITokenService _tokenService;
        public BankInformationController(ITokenService tokenService, IBankInformationService bankInformationService)
        {
            _tokenService = tokenService;
            _bankInformationService = bankInformationService;
        }
        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("bank-information")]
        public async Task<IActionResult> UpdateBankInformation([FromBody] UpdateBankInformationDTO updateBankInformationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _bankInformationService.UpdateBankInformation(currentUserObject, updateBankInformationDTO);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}