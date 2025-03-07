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
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private readonly TrixTutorDBContext _context;
        public FeedbackRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Feedback>> GetAllFeedbackByCourseId(int courseId)
        {
            return await _context.Feedback
                .Where(f => f.CourseId == courseId)
                .Include(c => c.Course)
                .Include(a => a.Account)
                .ToListAsync();
        }
        public async Task<int> CountAsync(int id)
        {
            IQueryable<Feedback> query = _context.Set<Feedback>()
                .Where(x => x.CourseId == id);

            return await query.CountAsync();
        }

    }
}
