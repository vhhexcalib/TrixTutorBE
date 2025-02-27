using Service.DTOs;
using Service.DTOs.CategoryDTO;
using Service.DTOs.TutorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITutorCategoryService
    {
        Task<PagedResult<TutorCategoryDTO>> GetAllCategoryAsync(string? search = null, bool sortByQuantityAsc = true, int page = 1, int size = 10);
        Task<dynamic> CreateCategory(CreateCategoryDTO createCategoryDTO);
        Task<PagedResult<TutorCategoryDTO>> GetAllCategoriesNoPagingAsync(string? search = null, bool sortByQuantityAsc = true);
    }
}
