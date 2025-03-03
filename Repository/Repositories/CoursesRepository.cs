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
    public class CoursesRepository : Repository<Courses>, ICoursesRepository
    {
        private readonly TrixTutorDBContext _context;
        public CoursesRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Courses?> GetCourseByName(string name)
        {
            return await _context.Courses.FirstOrDefaultAsync(a => a.CourseName.Contains(name));
        }
        public async Task<int> CountAsync(string? search = null)
        {
            IQueryable<Courses> query = _context.Set<Courses>();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.CourseName.Contains(search));
            }

            return await query.CountAsync();
        }
        public async Task<IEnumerable<Courses>> GetAllCourseByIsAccept(Expression<Func<Courses, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByCreateDateAsc = true)
        {
            IQueryable<Courses> query = _context.Set<Courses>();

            // Lọc theo isAccepted = false
            query = query.Where(a => !a.IsAccepted);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tìm kiếm theo Courses Name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.CourseName.Contains(search));
            }

            // Sắp xếp theo Create Date
            query = sortByCreateDateAsc
                ? query.OrderBy(a => a.CreateDate)
                : query.OrderByDescending(a => a.CreateDate);

            // Bao gồm các navigation properties (nếu có)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<IEnumerable<Courses>> GetAllCourseAccepted(Expression<Func<Courses, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByCreateDateAsc = true)
        {
            IQueryable<Courses> query = _context.Set<Courses>();

            // Lọc theo isAccepted = false
            query = query.Where(a => a.IsAccepted);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tìm kiếm theo Courses Name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.CourseName.Contains(search));
            }

            // Sắp xếp theo Create Date
            query = sortByCreateDateAsc
                ? query.OrderBy(a => a.CreateDate)
                : query.OrderByDescending(a => a.CreateDate);

            // Bao gồm các navigation properties (nếu có)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<IEnumerable<Courses>> GetAllCourse(Expression<Func<Courses, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByCreateDateAsc = true)
        {
            IQueryable<Courses> query = _context.Set<Courses>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tìm kiếm theo Courses Name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.CourseName.Contains(search));
            }

            // Sắp xếp theo Create Date
            query = sortByCreateDateAsc
                ? query.OrderBy(a => a.CreateDate)
                : query.OrderByDescending(a => a.CreateDate);

            // Bao gồm các navigation properties (nếu có)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<IEnumerable<Courses>> GetAllCourseByTutorId(int tutorid, Expression<Func<Courses, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByCreateDateAsc = true)
        {
            IQueryable<Courses> query = _context.Set<Courses>();
            query = query.Where(a => a.IsAccepted && a.TutorId == tutorid);
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tìm kiếm theo Courses Name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.CourseName.Contains(search));
            }

            // Sắp xếp theo Create Date
            query = sortByCreateDateAsc
                ? query.OrderBy(a => a.CreateDate)
                : query.OrderByDescending(a => a.CreateDate);

            // Bao gồm các navigation properties (nếu có)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<IEnumerable<Courses>> GetAllCourseByTutorToken(int tutorid, Expression<Func<Courses, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByCreateDateAsc = true)
        {
            IQueryable<Courses> query = _context.Set<Courses>();
            query = query.Where(a => a.TutorId == tutorid);
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tìm kiếm theo Courses Name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.CourseName.Contains(search));
            }

            // Sắp xếp theo Create Date
            query = sortByCreateDateAsc
                ? query.OrderBy(a => a.CreateDate)
                : query.OrderByDescending(a => a.CreateDate);

            // Bao gồm các navigation properties (nếu có)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<IEnumerable<Courses>> GetCourseToCheckTeachingDateTime(int tutorid, int teachingDate)
        {
            return await _context.Courses.Where(c => c.TutorId == tutorid && c.TeachingDateId == teachingDate).ToListAsync();
        }
    }
}
