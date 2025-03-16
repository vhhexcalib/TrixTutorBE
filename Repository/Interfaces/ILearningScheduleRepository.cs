using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILearningScheduleRepository : IRepository<LearningSchedule>
    {
        Task<IEnumerable<LearningSchedule>> GetLearningSchedulesByStudentId(int id);
        Task<int> CountAsync(int id);
        Task<LearningSchedule> GetLearningScheduleByStudentId(int id);
        Task<LearningSchedule> GetLearningScheduleToTakeAttendance(int tutorId, int studentId, int courseId, int slotNumber);
    }
}
