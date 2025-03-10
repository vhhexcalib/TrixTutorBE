﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.CategoryDTO;
using Service.DTOs.CoursesDTO;
using Service.Interfaces;
using Service.Services;
using TrixTutorAPI.Helper;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CourseController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }
        [HttpPost("course")]
        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCoursesDTO createCoursesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _coursesService.CreateCourse(currentUserObject, createCoursesDTO);
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
        [HttpGet("unaccepted-courses")]
        public async Task<IActionResult> GetAllCourseByIsAccept([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] bool sortByCreateDateAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetAllCourseByIsAcceptAsync(page, size, search, sortByCreateDateAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "SystemAccountOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("accepted-courses")]
        public async Task<IActionResult> GetAllCourseAccepted([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] bool sortByCreateDateAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetAllCourseAcceptedAsync(page, size, search, sortByCreateDateAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "SystemAccountOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("accept-course")]
        public async Task<IActionResult> AcceptingCourse([FromBody] CourseIdDTO courseIdDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.AcceptingCouse(courseIdDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("teaching-times")]
        public async Task<IActionResult> GetTeachingTimes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetTeachingTimeAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("teaching-dates")]
        public async Task<IActionResult> GetTeachingDates()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetTeachingDateAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("upload-image")]
        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadCourseImg([FromForm] CourseIdDTO courseIdDTO, IFormFile attachmentFile )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _coursesService.UploadCourseImages(attachmentFile, courseIdDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("upload-image-from-header")]
        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadCourseImgHeader([FromHeader] CourseIdDTO courseIdDTO, IFormFile attachmentFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _coursesService.UploadCourseImages(attachmentFile, courseIdDTO);
                if (result.IsSuccess) return Ok(result);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("courses")]
        public async Task<IActionResult> GetAllCourses([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] bool sortByCreateDateAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetAllCourse(page, size, search, sortByCreateDateAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("courses-by-tutor-id")]
        public async Task<IActionResult> GetAllCoursesByTutorId([FromQuery] TutorIdDTO tutorIdDTO,[FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] bool sortByCreateDateAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetAllCourseByTutorId(tutorIdDTO.TutorId ,page, size, search, sortByCreateDateAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize(Policy = "LecturerOnly")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("courses-by-tutor-token")]
        public async Task<IActionResult> GetAllCoursesByTutorToken([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] bool sortByCreateDateAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CurrentUserObject currentUserObject = await TokenHelper.Instance.GetThisUserInfo(HttpContext);
                var result = await _coursesService.GetAllCourseByTutorToken(currentUserObject, page, size, search, sortByCreateDateAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("course-detail")]
        public async Task<IActionResult> GetCourseDetail([FromQuery] CourseIdDTO courseIdDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _coursesService.GetCourseDetail(courseIdDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
