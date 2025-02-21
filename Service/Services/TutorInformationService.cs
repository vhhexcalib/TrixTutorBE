using AutoMapper;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Services
{
    public class TutorInformationService : ITutorInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICertFileService _certFileService;
        private readonly IMapper _mapper;

        public TutorInformationService(IUnitOfWork unitOfWork, IMapper mapper, ICertFileService certFileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _certFileService = certFileService;
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
            tutorProfile.TutorCategoryName = account.TutorInformation.TutorCategory?.Name ?? "Chưa có danh mục";

            return Result.SuccessWithObject(tutorProfile);
        }
        public async Task<dynamic> GetProfileById(int id)
        {
            var account = await _unitOfWork.TutorInformationRepository.GetProfile(id);
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
        public async Task<dynamic> UploadAvatar(IFormFile attachmentFile, CurrentUserObject currentUserObject)
        {
            // Validate file size
            if (attachmentFile.Length > 500 * 1024 * 1024)
            {
                return Result.Failure(TutorErrors.OverLimitSize);
            }

            try
            {
                // Save avata file
                var avaFileUrl = await _certFileService.SaveFile(attachmentFile);
                var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
                account.Avatar = avaFileUrl;
                // Save the avata to the database
                await _unitOfWork.AccountRepository.UpdateAsync(account);
                var saveResult = await _unitOfWork.SaveAsync();

                if (saveResult != "Save Change Success")
                {
                    return Result.Failure(TutorErrors.UploadFail);
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                // Log the error if needed
                return Result.Failure(TutorErrors.UploadFail);
            }
        }
        public async Task<dynamic> CreateTutorInformation(CurrentUserObject currentUserObject, TutorInformationDTO tutorInformationDTO)
        {
            var existTutor = await _unitOfWork.TutorInformationRepository.GetByIdAsync(currentUserObject.AccountId);
            if (existTutor != null)
            {
                return Result.Failure(TutorErrors.ExistTutorInformation);
            }
            var noneExistTutorCategory = await _unitOfWork.TutorCategoryRepository.GetByIdAsync(tutorInformationDTO.TutorCategoryId);
            if (noneExistTutorCategory == null)
            {
                return Result.Failure(TutorErrors.NoneExistTutorCategory);
            }
            var createdInformation = _mapper.Map<TutorInformation>(tutorInformationDTO);
            createdInformation.TutorId = currentUserObject.AccountId;
            var bankInformation = new BankInformation {TutorId = currentUserObject.AccountId, BankName = "bankname", BankNumber = "banknumber", OwnerName = "ownername" };
            noneExistTutorCategory.Quantity++;
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            await _unitOfWork.TutorInformationRepository.AddAsync(createdInformation);
            account.RoleId = 4;
            await _unitOfWork.AccountRepository.UpdateAsync(account);
            await _unitOfWork.BankInformationRepository.AddAsync(bankInformation);
            await _unitOfWork.TutorCategoryRepository.UpdateAsync(noneExistTutorCategory);
            await _unitOfWork.SaveAsync();
            var existedTutor = await _unitOfWork.TutorInformationRepository.GetByIdAsync(currentUserObject.AccountId);
            if (existedTutor == null)
            {
                return Result.Failure(TutorErrors.FailCreatingTutorInformation);
            }
            return Result.Success();
        }
    }
}
