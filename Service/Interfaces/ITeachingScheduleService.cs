using BusinessObject;
using Service.DTOs.AccountDTO;
using Service.DTOs.TeachingDTO;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITeachingScheduleService
    {
        Task<dynamic> AddTeachingSchedulesAsync(string orderId);
        Task<PagedResult<TeachingDTO>> GetAllTeachingScheduleByTutorIdAsync(CurrentUserObject currentUserObject);
        Task<dynamic> TakeStudentAttendance(int slotId, int flag);
    }
}
