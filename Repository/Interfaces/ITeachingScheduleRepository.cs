using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITeachingScheduleRepository : IRepository<TeachingSchedule>
    {
        Task<IEnumerable<TeachingSchedule>> GetTeachingSchedulesByTutorId(int id);
        Task<int> CountAsync(int id);
        Task<TeachingSchedule> GetTeachingScheduleToTakeAttendance(int tutorId, int studentId, int courseId, int slotNumber);
    }
}
