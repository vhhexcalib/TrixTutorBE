using Service.DTOs.AccountDTO;
using Service.DTOs.CoursesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICoursesService
    {
        Task<dynamic> CreateCourse(CurrentUserObject currentUserObject, CreateCoursesDTO createCoursesDTO);
    }
}
