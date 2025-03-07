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
    public class LearningScheduleRepository : Repository<LearningSchedule>, ILearningScheduleRepository
    {
        private readonly TrixTutorDBContext _context;
        public LearningScheduleRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LearningSchedule>> GetLearningSchedulesByStudentId(int id)
        {
            return await _context.LearningSchedule
                .Where(p => p.StudentId == id)
                .Include(o => o.Course)
                .ThenInclude(c => c.TutorInformation)
                .ThenInclude(ti => ti.Account)
                .ToListAsync();
        }
        public async Task<LearningSchedule> GetLearningScheduleByStudentId(int id)
        {
            return await _context.LearningSchedule.Where(p => p.StudentId == id).FirstOrDefaultAsync();
        }
        public async Task<int> CountAsync()
        {
            IQueryable<LearningSchedule> query = _context.Set<LearningSchedule>();

            return await query.CountAsync();
        }
    }
}
