﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using AutoMapper;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using Service.Exceptions;
using Service.DTOs.CategoryDTO;
using System.Linq.Expressions;

namespace Service.Services
{
    public class TutorCategoryService : ITutorCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TutorCategoryDTO>> GetAllCategoryAsync(string? search = null,bool sortByQuantityAsc = true,int page = 1,int size = 10)
        {
            // Gọi repository để lấy danh mục có tìm kiếm và sắp xếp
            var categories = await _unitOfWork.TutorCategoryRepository.GetAllTutorCategoriesAsync(
                search, sortByQuantityAsc, page, size);

            // Ánh xạ danh mục sang DTO
            return _mapper.Map<IEnumerable<TutorCategoryDTO>>(categories);
        }

        public async Task<dynamic> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = new TutorCategory() {Name = createCategoryDTO.CategoryName, Quantity = 0 };
            var categorybyname = await _unitOfWork.TutorCategoryRepository.GetTutorCategoryByName(category.Name);
            if(categorybyname == null)
            {
                return Result.Failure(CategoryErrors.ExistedCategory);
            }
            await _unitOfWork.TutorCategoryRepository.AddAsync(category);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(CategoryErrors.CreateCategoryFailed);
            }
        }
    }
}