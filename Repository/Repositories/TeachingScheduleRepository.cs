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
    public class TeachingScheduleRepository : Repository<TeachingSchedule>, ITeachingScheduleRepository
    {
        private readonly TrixTutorDBContext _context;
        public TeachingScheduleRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TeachingSchedule>> GetTeachingSchedulesByTutorId(int id)
        {
            return await _context.TeachingSchedules
                .Where(p => p.TutorId == id)
                .Include(o => o.Course)
                .Include(ti => ti.Account)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            IQueryable<TeachingSchedule> query = _context.Set<TeachingSchedule>();

            return await query.CountAsync();
        }
    }
}
