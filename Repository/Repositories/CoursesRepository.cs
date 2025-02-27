using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
