﻿using AutoMapper;
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
            createdInformation.TotalTeachDay = 0;
            createdInformation.IsRented = true;
            var bankInformation = new BankInformation { TutorId = currentUserObject.AccountId, BankName = "bankname", BankNumber = "banknumber", OwnerName = "ownername" };
            noneExistTutorCategory.Quantity++;
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            await _unitOfWork.TutorInformationRepository.AddAsync(createdInformation);
            account.RoleId = 4;
            await _unitOfWork.AccountRepository.UpdateAsync(account);
            await _unitOfWork.BankInformationRepository.AddAsync(bankInformation);
            await _unitOfWork.TutorCategoryRepository.UpdateAsync(noneExistTutorCategory);
            await _unitOfWork.SaveAsync();
            Wallet wallet = new Wallet() {TutorId = currentUserObject.AccountId, Balance = 0, LastChangeAmount = 0, LastChangeDate = DateTime.Now };
            await _unitOfWork.WalletRepository.AddAsync(wallet);
            await _unitOfWork.SaveAsync();
            var existedTutor = await _unitOfWork.TutorInformationRepository.GetByIdAsync(currentUserObject.AccountId);
            if (existedTutor == null)
            {
                return Result.Failure(TutorErrors.FailCreatingTutorInformation);
            }
            return Result.Success();
        }
        public async Task<dynamic> GetTutorWallet(CurrentUserObject currentUserObject)
        {
            var wallets = await _unitOfWork.WalletRepository.GetByIdAsync(currentUserObject.AccountId);
            WalletDTO wallet = new WalletDTO()
            {
                Balance = wallets.Balance,
                LastChangeAmount = wallets.LastChangeAmount,
                LastChangeDate = wallets.LastChangeDate
            };
            return Result.SuccessWithObject(wallet);
        }
         public async Task<dynamic> UpdateProfile(CurrentUserObject currentUserObject, EditTutorProfileDTO tutorProfileDTO)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            var tutorinformation = await _unitOfWork.TutorInformationRepository.GetByIdAsync(currentUserObject.AccountId);
            account.Address = tutorProfileDTO.Address;
            account.Birthday = tutorProfileDTO.Birthday;
            account.Phone = tutorProfileDTO.Phone;
            account.Name = tutorProfileDTO.Name;
            tutorinformation.GeneralProfile = tutorProfileDTO.GeneralProfile;
            tutorinformation.Language = tutorProfileDTO.Language;
            tutorinformation.Degree = tutorProfileDTO.Degree;
            tutorinformation.ExperienceYear = tutorProfileDTO.ExperienceYear;
            tutorinformation.SalaryPerHour = tutorProfileDTO.SalaryPerHour;
            tutorinformation.TeachingStyle = tutorProfileDTO.TeachingStyle;
            var foundCategory = await _unitOfWork.TutorCategoryRepository.GetByIdAsync(tutorProfileDTO.TutorCategoryId);
            if(foundCategory == null)
            {
                return Result.Failure(CategoryErrors.NoneExistCategory);
            }
            if (tutorProfileDTO.TutorCategoryId != tutorinformation.TutorCategoryId)
            {
                var oldCategory = await _unitOfWork.TutorCategoryRepository.GetByIdAsync(tutorinformation.TutorCategoryId);
                oldCategory.Quantity--;
                var newCategory = await _unitOfWork.TutorCategoryRepository.GetByIdAsync(tutorProfileDTO.TutorCategoryId);
                newCategory.Quantity++;
                await _unitOfWork.TutorCategoryRepository.UpdateAsync(oldCategory);
                await _unitOfWork.TutorCategoryRepository.UpdateAsync(newCategory);
            }
            tutorinformation.TutorCategoryId = tutorProfileDTO.TutorCategoryId;
            tutorinformation.TotalTeachDay = tutorProfileDTO.TotalTeachDay;
            await _unitOfWork.TutorInformationRepository.UpdateAsync(tutorinformation);
            await _unitOfWork.AccountRepository.UpdateAsync(account);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(AccountErrors.FailUpdateProfile);
        }
    }
}
