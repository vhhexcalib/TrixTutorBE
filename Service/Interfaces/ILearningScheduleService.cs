using Service.DTOs.AccountDTO;
using Service.DTOs.LearningDTO;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILearningScheduleService
    {
        Task<dynamic> AddLearningSchedulesAsync(string orderId);
        Task<PagedResult<LearningDTO>> GetAllLearningScheduleByStudentIdAsync(CurrentUserObject currentUserObject);
        Task<dynamic> TakeTutorAttendance(int slotId, int flag);
    }
}
