using BusinessObject;
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
using Service.DTOs;

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
        public async Task<PagedResult<TutorCategoryDTO>> GetAllCategoryAsync(string? search = null, bool sortByQuantityAsc = true, int page = 1, int size = 10)
        {
            // Lấy danh mục có tìm kiếm và sắp xếp
            var categories = await _unitOfWork.TutorCategoryRepository.GetAllTutorCategoriesAsync(
                search, sortByQuantityAsc, page, size);

            // Đếm tổng số danh mục để tính phân trang
            int totalItems = await _unitOfWork.TutorCategoryRepository.CountTutorCategoriesAsync(search);
            int totalPages = (int)Math.Ceiling((double)totalItems / size);

            // Ánh xạ danh mục sang DTO
            var categoryDtos = _mapper.Map<IEnumerable<TutorCategoryDTO>>(categories);

            // Trả về kết quả dưới dạng PagedResult
            return new PagedResult<TutorCategoryDTO>
            {
                Items = categoryDtos,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }
        public async Task<PagedResult<TutorCategoryDTO>> GetAllCategoriesNoPagingAsync(string? search = null, bool sortByQuantityAsc = true)
        {
            // Lấy danh mục có tìm kiếm và sắp xếp
            var categories = await _unitOfWork.TutorCategoryRepository.GetAllCategoriesNoPagingAsync(
                search, sortByQuantityAsc);

            // Đếm tổng số danh mục để tính phân trang
            int totalItems = await _unitOfWork.TutorCategoryRepository.CountTutorCategoriesAsync(search);

            // Ánh xạ danh mục sang DTO
            var categoryDtos = _mapper.Map<IEnumerable<TutorCategoryDTO>>(categories);

            // Trả về kết quả dưới dạng PagedResult
            return new PagedResult<TutorCategoryDTO>
            {
                Items = categoryDtos,
                TotalItems = totalItems
            };
        }

        public async Task<dynamic> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = new TutorCategory() {Name = createCategoryDTO.CategoryName, Quantity = 0, RentingQuantity = 0 };
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