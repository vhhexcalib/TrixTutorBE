using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ITutorCategoryService _tutorCategoryService;
        public CategoryController(ITutorCategoryService tutorCategoryService)
        {
            _tutorCategoryService = tutorCategoryService;
        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetProfileById()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _tutorCategoryService.GetAllCategoryAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
