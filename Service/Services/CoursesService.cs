using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.CoursesDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoursesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> CreateCourse(CurrentUserObject currentUserObject, CreateCoursesDTO createCoursesDTO)
        {
            var courseNameExist = await _unitOfWork.CoursesRepository.GetCourseByName(createCoursesDTO.CourseName);
            if (courseNameExist != null)
            {
                return Result.Failure(CoursesErrors.ExistCourseName);
            }

            var createdcourse = _mapper.Map<Courses>(createCoursesDTO);
            createdcourse.CreateDate = DateTime.Now;
            createdcourse.TutorId = currentUserObject.AccountId;
            createdcourse.IsAccepted = false;
            createdcourse.IsLocked = false;
            await _unitOfWork.CoursesRepository.AddAsync(createdcourse);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(CoursesErrors.CreateCourseFail);
            }
        }
        public async Task<PagedResult<AllCoursesDTO>> GetAllCourseByIsAcceptAsync(int page, int size, string? search = null, bool sortByCreateDateAsc = true)
        {
            var courses = await _unitOfWork.CoursesRepository.GetAllCourseByIsAccept(page: page, size: size, search: search, sortByCreateDateAsc: sortByCreateDateAsc);
            var totalItems = await _unitOfWork.CoursesRepository.CountAsync(search); // Đếm tổng số course phù hợp

            return new PagedResult<AllCoursesDTO>
            {
                Items = _mapper.Map<IEnumerable<AllCoursesDTO>>(courses),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / size)
            };
        }
        public async Task<dynamic> AcceptingCouse(CoursesAcceptDTO coursesAcceptDTO)
        {
            var course = await _unitOfWork.CoursesRepository.GetByIdAsync(coursesAcceptDTO.CourseId);
            var teachingtime = await _unitOfWork.tea
                var teachingdate = 
            if(course == null)
            {
                return Result.Failure(CoursesErrors.FailGetById);
            }
            if(coursesAcceptDTO.)
            course.IsAccepted = true;
            await _unitOfWork.CoursesRepository.UpdateAsync(course);
            var result = await _unitOfWork.SaveAsync();
            if (result == "Save Change Success")
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(CoursesErrors.AcceptCourseFail);
            }
        }
    }
}
