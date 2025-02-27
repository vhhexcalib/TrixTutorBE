using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TutorCategoryRepository : Repository<TutorCategory>, ITutorCategoryRepository
    {
        private readonly TrixTutorDBContext _context;
        public TutorCategoryRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<TutorCategory> GetTutorCategoryByName(string name)
        {
            var category = await _context.TutorCategory.FirstOrDefaultAsync(x => x.Name == name);
            return category;
        }
        public async Task<IEnumerable<TutorCategory>> GetAllTutorCategoriesAsync(string? search = null,bool sortByQuantityAsc = true,int page = 1,int size = 10)
        {
            var query = _context.TutorCategory.AsQueryable();

            // Nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            // Sắp xếp theo Quantity
            query = sortByQuantityAsc ? query.OrderBy(c => c.Quantity) : query.OrderByDescending(c => c.Quantity);

            // Phân trang
            var categories = await query.Skip((page - 1) * size).Take(size).ToListAsync();

            return categories;
        }
        public async Task<int> CountTutorCategoriesAsync(string? search = null)
        {
            var query = _context.TutorCategory.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            return await query.CountAsync();
        }
        public async Task<IEnumerable<TutorCategory>> GetAllCategoriesNoPagingAsync(string? search = null, bool sortByQuantityAsc = true)
        {
            var query = _context.TutorCategory.AsQueryable();

            // Nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            // Sắp xếp theo Quantity
            query = sortByQuantityAsc ? query.OrderBy(c => c.Quantity) : query.OrderByDescending(c => c.Quantity);

            // Trả về toàn bộ danh mục mà không phân trang
            return await query.ToListAsync();
        }
    }
}
