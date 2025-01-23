using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using AutoMapper;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using Service.Exceptions;

namespace Service.Services
{
    public class TutorCategoryService : ITutorCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TutorCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TutorCategoryDTO>> GetAllCategoryAsync()
        {
            var categories = await _unitOfWork.TutorCategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TutorCategoryDTO>>(categories);
        }
        public async Task<dynamic> GetProfile(CurrentUserObject currentUserObject)
        {
            var account = await _unitOfWork.TutorInformationRepository.GetProfile(currentUserObject.AccountId);
            if (account == null || account.TutorInformation == null)
            {
                return Result.Failure(TutorErrors.FailGettingAccount);
            }

            var tutorProfile = _mapper.Map<TutorProfileDTO>(account);

            // Lấy tên danh mục
            var tutorCategory = await _unitOfWork.TutorCategoryRepository.GetByIdAsync(account.TutorInformation.TutorCategoryId);
            tutorProfile.TutorCategoryName = tutorCategory.Name;

            return Result.SuccessWithObject(tutorProfile);
        }
    }
}