using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITeachingScheduleService
    {
        Task<dynamic> AddTeachingSchedulesAsync(IEnumerable<TeachingSchedule> schedules);
    }
}
