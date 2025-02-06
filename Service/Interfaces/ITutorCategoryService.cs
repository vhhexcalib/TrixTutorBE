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
        Task<IEnumerable<TutorCategoryDTO>> GetAllCategoryAsync();
        Task<dynamic> CreateCategory(CreateCategoryDTO createCategoryDTO);
    }
}
