using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.CategoryDTO;
using Service.DTOs.CoursesDTO;
using Service.DTOs.FeedBackDTO;
using Service.Interfaces;
using Service.Services;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost("feedback")]
        [Authorize(Policy = "StudentOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _feedbackService.CreateFeedBackForCourse(currentUserObject, feedbackDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("feedbacks-by-course-id")]
        public async Task<IActionResult> GetFeedbacks([FromQuery] CourseIdDTO courseIdDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _feedbackService.GetAllCourseFeedbackAsync(courseIdDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
