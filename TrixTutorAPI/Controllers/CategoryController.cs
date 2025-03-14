﻿using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTO;
using Service.DTOs.CategoryDTO;
using Service.Interfaces;
using Service.Services;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ITutorCategoryService _tutorCategoryService;
        public CategoryController(ITutorCategoryService tutorCategoryService)
        {
            _tutorCategoryService = tutorCategoryService;
        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories([FromQuery] int page = 1,[FromQuery] int size = 10,[FromQuery] string? search = null,[FromQuery] bool sortByQuantityAsc = true) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _tutorCategoryService.GetAllCategoryAsync(search, sortByQuantityAsc, page, size);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("categories-no-paging")]
        public async Task<IActionResult> GetAllCategoriesNoPaging([FromQuery] string? search = null, [FromQuery] bool sortByQuantityAsc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _tutorCategoryService.GetAllCategoriesNoPagingAsync(search, sortByQuantityAsc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("category")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var result = await _tutorCategoryService.CreateCategory(createCategoryDTO);
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
