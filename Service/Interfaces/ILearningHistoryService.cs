using Service.DTOs.AccountDTO;
using Service.DTOs.LearningHistoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILearningHistoryService
    {
        Task<dynamic> CreateLearningHistory(int studentId, CreateLearningHistoryDTO createLearningHistoryDTO);
    }
}
