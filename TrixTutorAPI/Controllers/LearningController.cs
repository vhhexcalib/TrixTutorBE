using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.LearningDTO;
using Service.Interfaces;
using Service.Services;
using System.ComponentModel;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILearningScheduleService _learningScheduleService;
        private readonly ITokenService _tokenService;

        public LearningController(ITokenService tokenService, ILearningScheduleService learningScheduleService)
        {
            _tokenService = tokenService;
            _learningScheduleService = learningScheduleService;
        }
        [Authorize(Policy = "StudentOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("tutor-attendance")]
        public async Task<IActionResult> TakeTutorAttendance([FromBody] AttendanceDTO attendanceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _learningScheduleService.TakeTutorAttendance(attendanceDTO.slotId, attendanceDTO.flag);
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
        [HttpGet("student-learning-schedule")]
        public async Task<IActionResult> GetLeaningScheduleByStudentId()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _learningScheduleService.GetAllLearningScheduleByStudentIdAsync(currentUserObject);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
