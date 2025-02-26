using Service.DTOs.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.FeedBackDTO;

namespace Service.Interfaces
{
    public interface IFeedbackService
    {
        Task<dynamic> CreateFeedBackForCourse(CurrentUserObject currentUserObject, FeedbackDTO feedbackDTO);
        Task<IEnumerable<FeedbackDTO>> GetAllFeedbackByUserIdAsync(int userId);
    }
}
