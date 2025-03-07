using Service.DTOs.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.FeedBackDTO;
using Service.DTOs.CoursesDTO;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IFeedbackService
    {
        Task<dynamic> CreateFeedBackForCourse(CurrentUserObject currentUserObject, FeedbackDTO feedbackDTO);
        Task<PagedResult<GetFeedbackDTO>> GetAllCourseFeedbackAsync(CourseIdDTO courseIdDTO);
    }
}
