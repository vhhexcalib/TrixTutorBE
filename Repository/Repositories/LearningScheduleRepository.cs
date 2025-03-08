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
        public async Task<int> CountAsync(int id)
        {
            IQueryable<LearningSchedule> query = _context.Set<LearningSchedule>()
                .Where(x => x.TutorId == id);

            return await query.CountAsync();
        }
        public async Task<LearningSchedule> GetLearningScheduleToTakeAttendance(int studentId, DateTime TeachingDate, int TeachingTime)
        {
            return await _context.LearningSchedule
                .Where(p => p.StudentId == studentId && p.LearningDate == TeachingDate && p.LearningTime == TeachingTime)
                .FirstOrDefaultAsync();
        }
    }
}
