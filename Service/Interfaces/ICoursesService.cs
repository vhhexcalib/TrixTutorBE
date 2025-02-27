using BusinessObject;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.CoursesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICoursesService
    {
        Task<dynamic> CreateCourse(CurrentUserObject currentUserObject, CreateCoursesDTO createCoursesDTO);
        Task<PagedResult<AllCoursesDTO>> GetAllCourseByIsAcceptAsync(int page, int size, string? search = null, bool sortByCreateDateAsc = true);
        Task<dynamic> AcceptingCouse(CoursesAcceptDTO coursesAcceptDTO);
    }
}
