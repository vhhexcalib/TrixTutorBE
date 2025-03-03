using BusinessObject;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Service.DTOs.AccountDTO;
using Service.DTOs.PaymentDTO;
using Service.Interfaces;
using Service.Services;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IPayOsService _payOsService;


        public PaymentController(ITokenService tokenService, IPayOsService payOsService)
        {
            _tokenService = tokenService;
            _payOsService = payOsService;
        }
        [Authorize(Policy = "UserOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("create-payment-link")]
        public async Task<IActionResult> CreateSalePayment(PaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _payOsService.CreatePayment(currentUserObject, paymentDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("payment-link-info/{orderId}")]        //.pay info
        public async Task<IActionResult> GetPaymentLinkInformation(string orderId)
        {
            var result = await _payOsService.GetPaymentLinkInformation(orderId);
            return Ok(result);
        }
        [HttpPost("cancel-payment-link")]     //.cancel payment
        public async Task<IActionResult> CancelPaymentLink(PaymentDTO paymentDTO)
        {
            var result = await _payOsService.CancelPaymentLink(paymentDTO.OrderId);
            return Ok(result);
        }
        [HttpGet("order-id")]
        public async Task<IActionResult> GetOrderIdByPaymentId(PaymentIdDTO paymentIdDTO)
        {
            var result = await _payOsService.GetOrderIdByPaymentId(paymentIdDTO.PaymentId);
            return Ok(result);
        }
    }
}
