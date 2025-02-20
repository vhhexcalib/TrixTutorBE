﻿using Service.DTOs.CategoryDTO;
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
        Task<IEnumerable<TutorCategoryDTO>> GetAllCategoryAsync(string? search = null, bool sortByQuantityAsc = true, int page = 1, int size = 10);
        Task<dynamic> CreateCategory(CreateCategoryDTO createCategoryDTO);
    }
}
