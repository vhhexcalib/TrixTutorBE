using Service.DTOs.LearningHistoryDTO;
using Service.DTOs.TeachingHistoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITeachingHistoryService
    {
        Task<dynamic> CreateTeachingHistory(int studentId, CreateTeachingHistoryDTO createTeachingHistoryDTO);
    }
}
