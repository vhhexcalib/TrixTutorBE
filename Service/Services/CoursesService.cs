using AutoMapper;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.CoursesDTO;
using Service.DTOs.TutorDTO;
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
        private readonly ICertFileService _certFileService;
        public CoursesService(IUnitOfWork unitOfWork, IMapper mapper, ICertFileService certFileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _certFileService = certFileService;
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
            createdcourse.Images = "courseImg";
            createdcourse.TeachingDateId = createCoursesDTO.TeachingDateId;
            createdcourse.TeachingTimeId = createCoursesDTO.TeachingTimeId;
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
        public async Task<PagedResult<AllCourseByTutorIdDTO>> GetAllCourse(int page, int size, string? search = null, bool sortByCreateDateAsc = true)
        {
            var courses = await _unitOfWork.CoursesRepository.GetAllCourse(page: page, size: size, search: search, sortByCreateDateAsc: sortByCreateDateAsc);
            var totalItems = await _unitOfWork.CoursesRepository.CountAsync(search); // Đếm tổng số course phù hợp

            return new PagedResult<AllCourseByTutorIdDTO>
            {
                Items = _mapper.Map<IEnumerable<AllCourseByTutorIdDTO>>(courses),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / size)
            };
        }
        public async Task<PagedResult<AllCourseByTutorIdDTO>> GetAllCourseByTutorId(int tutorid ,int page, int size, string? search = null, bool sortByCreateDateAsc = true)
        {
            var courses = await _unitOfWork.CoursesRepository.GetAllCourseByTutorId(tutorid ,page: page, size: size, search: search, sortByCreateDateAsc: sortByCreateDateAsc);
            var totalItems = await _unitOfWork.CoursesRepository.CountAsync(search); // Đếm tổng số course phù hợp

            return new PagedResult<AllCourseByTutorIdDTO>
            {
                Items = _mapper.Map<IEnumerable<AllCourseByTutorIdDTO>>(courses),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / size)
            };
        }
        public async Task<PagedResult<AllCoursesDTO>> GetAllCourseAcceptedAsync(int page, int size, string? search = null, bool sortByCreateDateAsc = true)
        {
            var courses = await _unitOfWork.CoursesRepository.GetAllCourseAccepted(page: page, size: size, search: search, sortByCreateDateAsc: sortByCreateDateAsc);
            var totalItems = await _unitOfWork.CoursesRepository.CountAsync(search); // Đếm tổng số course phù hợp

            return new PagedResult<AllCoursesDTO>
            {
                Items = _mapper.Map<IEnumerable<AllCoursesDTO>>(courses),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / size)
            };
        }
        public async Task<dynamic> AcceptingCouse(CourseIdDTO courseIdDTO)
        {
            var course = await _unitOfWork.CoursesRepository.GetByIdAsync(courseIdDTO.CourseId);
            if (course == null)
            {
                return Result.Failure(CoursesErrors.FailGetById);
            }
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
        public async Task<IEnumerable<TeachingTimeDTO>> GetTeachingTimeAsync()
        {
            var teachingTimes = await _unitOfWork.TeachingTimeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeachingTimeDTO>>(teachingTimes);
        }
        public async Task<IEnumerable<TeachingDateDTO>> GetTeachingDateAsync()
        {
            var teachingDates = await _unitOfWork.TeachingDateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeachingDateDTO>>(teachingDates);
        }
        public async Task<dynamic> GetCourseDetail(CourseIdDTO courseIdDTO)
        {
            var course = await _unitOfWork.CoursesRepository.GetByIdAsync(courseIdDTO.CourseId);
            if(course == null)
            {
                return Result.Failure(CoursesErrors.FailGetCourseDetail);
            }
            var courseDetail = _mapper.Map<CourseDetailDTO>(course);
            return Result.SuccessWithObject(courseDetail);
        }
        public async Task<dynamic> UploadCourseImages(IFormFile attachmentFile, CourseIdDTO courseIdDTO)
        {
            var existedCourse = await _unitOfWork.CoursesRepository.GetByIdAsync(courseIdDTO.CourseId);
            if(existedCourse == null)
            {
                return Result.Failure(CoursesErrors.FailGetById);
            }
            // Validate file size
            if (attachmentFile.Length > 500 * 1024 * 1024)
            {
                return Result.Failure(CoursesErrors.OverLimitSize);
            }
            // Validate file type (only images)
            var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var fileExtension = Path.GetExtension(attachmentFile.FileName).ToLower();

            if (!permittedExtensions.Contains(fileExtension))
            {
                return Result.Failure(CoursesErrors.WrongTypeOfImage);
            }
            try
            {
                // Save avata file
                var avaFileUrl = await _certFileService.SaveFile(attachmentFile);
                var course = await _unitOfWork.CoursesRepository.GetByIdAsync(courseIdDTO.CourseId);
                course.Images = avaFileUrl;
                // Save the avata to the database
                await _unitOfWork.CoursesRepository.UpdateAsync(course);
                var saveResult = await _unitOfWork.SaveAsync();

                if (saveResult != "Save Change Success")
                {
                    return Result.Failure(CoursesErrors.UploadImageFail);
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                // Log the error if needed
                return Result.Failure(CoursesErrors.UploadImageFail);
            }
        }
    }
}
