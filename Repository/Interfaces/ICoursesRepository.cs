using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICoursesRepository : IRepository<Courses>
    {
        Task<Courses?> GetCourseByName(string name);
        Task<int> CountAsync(string? search = null);
        Task<IEnumerable<Courses>> GetAllCourseByIsAccept(Expression<Func<Courses, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByCreateDateAsc = true);
    }
}
