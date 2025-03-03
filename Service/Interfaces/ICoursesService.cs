using BusinessObject;
using Microsoft.AspNetCore.Http;
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
        Task<dynamic> AcceptingCouse(CourseIdDTO courseIdDTO);
        Task<PagedResult<AllCoursesDTO>> GetAllCourseAcceptedAsync(int page, int size, string? search = null, bool sortByCreateDateAsc = true);
        Task<IEnumerable<TeachingTimeDTO>> GetTeachingTimeAsync();
        Task<IEnumerable<TeachingDateDTO>> GetTeachingDateAsync();
        Task<dynamic> UploadCourseImages(IFormFile attachmentFile, CourseIdDTO coursesAcceptDTO);
        Task<PagedResult<AllCourseByTutorIdDTO>> GetAllCourse(int page, int size, string? search = null, bool sortByCreateDateAsc = true);
        Task<PagedResult<AllCourseByTutorIdDTO>> GetAllCourseByTutorId(int tutorid, int page, int size, string? search = null, bool sortByCreateDateAsc = true);
        Task<dynamic> GetCourseDetail(CourseIdDTO courseIdDTO);
        Task<PagedResult<AllCourseByTutorIdDTO>> GetAllCourseByTutorToken(CurrentUserObject currentUserObject, int page, int size, string? search = null, bool sortByCreateDateAsc = true);
    }
}
