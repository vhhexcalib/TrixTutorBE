using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.LearningDTO;
using Service.DTOs.TeachingDTO;
using Service.Interfaces;
using Service.Services;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingController : ControllerBase
    {
        private readonly ITeachingScheduleService _teachingScheduleService;
        private readonly ITokenService _tokenService;

        public TeachingController(ITokenService tokenService, ITeachingScheduleService teachingScheduleService)
        {
            _tokenService = tokenService;
            _teachingScheduleService = teachingScheduleService;
        }

        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("tutor-teaching-schedule")]
        public async Task<IActionResult> GetTeachingScheduleByTutorId()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _teachingScheduleService.GetAllTeachingScheduleByTutorIdAsync(currentUserObject);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("student-attendance")]
        public async Task<IActionResult> TakeStudentAttendance([FromBody] AttendanceDTO attendanceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _teachingScheduleService.TakeStudentAttendance(attendanceDTO.slotId, attendanceDTO.flag);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
