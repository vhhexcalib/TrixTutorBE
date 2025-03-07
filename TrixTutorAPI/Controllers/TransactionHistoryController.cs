using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.OrderDTO;
using Service.DTOs.TransactionHistoryDTO;
using Service.Interfaces;
using Service.Services;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ITransactionHistoryService _transactionHistoryService;
        public TransactionHistoryController(ITokenService tokenService, ITransactionHistoryService transactionHistoryService)
        {
            _tokenService = tokenService;
            _transactionHistoryService = transactionHistoryService;
        }
        [Authorize(Policy = "StudentOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("student-transactions-by-token")]
        public async Task<IActionResult> GetStudentTransactionByToken()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _transactionHistoryService.GetAllStudentTransactionAsync(currentUserObject);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        //[Authorize(Policy = "StudentOnly")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost("transaction")]
        //public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDTO createTransactionDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
        //        var result = await _transactionHistoryService.CreateTransactionAsync(currentUserObject, createTransactionDTO);
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
