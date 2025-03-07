using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Common;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.TokenDTO;
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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IConfirmationOTPService _confirmationOTPService;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, IEmailService emailService, IConfirmationOTPService confirmationOTPService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailService = emailService;
            _confirmationOTPService = confirmationOTPService;
        }
        public async Task<dynamic> LoginAsync(LoginDTO loginDTO)
        {
            var logacc = _mapper.Map<Account>(loginDTO);
            string hashPassword = await HassPassword.HassPass(logacc.Password);
            var account = await _unitOfWork.AccountRepository.LoginAsync(logacc.Email, hashPassword);
            if (account != null)
            {
                if (account.IsBan) return Result.Failure(LoginErrors.AccountIsBan);
                if (!account.IsEmailConfirm) return Result.Failure(LoginErrors.AccountUnverified);
                var currentUser = _mapper.Map<CurrentUserObject>(account);
                currentUser.AccountEmail = account.Email;
                currentUser.AccountId = account.Id;
                currentUser.RoleId = account.RoleId;
                currentUser.AccountName = account.Name;
                var token = await _tokenService.GenerateTokenAsync(currentUser);
                var accesstoken = await _tokenService.GenerateAccessTokenAsync(token);
                var tokenDTO = new TokenDTO
                {
                    AccessToken = accesstoken
                };
                return Result.SuccessWithObject(tokenDTO);
            }
            else
            {
                return Result.Failure(LoginErrors.InvalidAccount);
            }
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _unitOfWork.AccountRepository.CheckEmailExistAsync(email);
        }

        public async Task<bool> CheckPhoneExistAsync(string phone)
        {
            return await _unitOfWork.AccountRepository.CheckPhoneExistAsync(phone);
        }
        public async Task<dynamic> CreateAccount(RegisterAccountDTO registerAccount)
        {
            if (await _unitOfWork.AccountRepository.CheckEmailExistAsync(registerAccount.Email))
            {
                return Result.Failure(RegisterErrors.InvalidEmail);
            }
            if (await _unitOfWork.AccountRepository.CheckPhoneExistAsync(registerAccount.Phone))
            {
                return Result.Failure(RegisterErrors.InvalidPhone);
            }

            var createdAccount = _mapper.Map<Account>(registerAccount);
            createdAccount.Password = await HassPassword.HassPass(registerAccount.Password);
            createdAccount.IsEmailConfirm = false;
            createdAccount.IsBan = false;
            createdAccount.RoleId = 3;
            createdAccount.Avatar = "avatar link";
            await _unitOfWork.AccountRepository.CreateAccount(createdAccount);
            await _unitOfWork.SaveAsync();
            var existedaccount = await _unitOfWork.AccountRepository.GetAccountByEmail(registerAccount.Email);
            if (existedaccount == null)
            {
                return Result.Failure(RegisterErrors.InvalidEmail);
            }
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(createdAccount.RoleId);
            role.Quantity++;
            await _unitOfWork.RoleRepository.UpdateAsync(role);
            await _unitOfWork.SaveAsync();
            await _emailService.SendEmail(createdAccount.Email);
            return Result.Success();
        }
        public async Task<dynamic> OTPConfirmation(string email, string otp)
        {
            string encodedOtp = await HassPassword.HassPass(otp);
            var otpfounded = await _unitOfWork.ConfirmationOTPRepository.GetOTPByEmail(email);

            if (otpfounded != null)
            {
                if (otpfounded.OTP == encodedOtp)
                {
                    await _unitOfWork.ConfirmationOTPRepository.DeleteAsync(otpfounded);
                    var account = await _unitOfWork.AccountRepository.GetAccountByEmail(email);
                    account.IsEmailConfirm = true;
                    await _unitOfWork.AccountRepository.UpdateAsync(account);
                    await _unitOfWork.SaveAsync();
                    return Result.Success();
                }
                else
                {
                    return Result.Failure(OTPErrors.IncorrectOTP);
                }
            }
            else
            {
                return Result.Failure(OTPErrors.InvalidOTP);
            }
        }
        public async Task<dynamic> ChangePassword(PasswordDTO password, CurrentUserObject currentUserObject)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            string oldPassword = await HassPassword.HassPass(password.OldPassword);
            if (account.Password == oldPassword)
            {
                account.Password = await HassPassword.HassPass(password.NewPassword);
                var update = await _unitOfWork.AccountRepository.UpdateAsync(account);
                await _unitOfWork.SaveAsync();
                return Result.Success();
            }
            else
            {
                return Result.Failure(ChangePasswordErrors.WrongOldPassword);
            }
        }
        public async Task<dynamic> GetProfile(CurrentUserObject currentUserObject)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            ProfileDTO profile = new ProfileDTO()
            {
                Email = account.Email,
                Address = account.Address,
                Birthday = account.Birthday,
                Phone = account.Phone,
                Avatar = account.Avatar,
                Name = account.Name
            };
            return Result.SuccessWithObject(profile);
        }
        public async Task<dynamic> UpdateProfile(CurrentUserObject currentUserObject, ProfileDTO profileDTO)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(currentUserObject.AccountId);
            account.Address = profileDTO.Address;
            account.Birthday = profileDTO.Birthday;
            account.Phone = profileDTO.Phone;
            account.Avatar = profileDTO.Avatar;
            account.Name = profileDTO.Name;
            await _unitOfWork.AccountRepository.UpdateAsync(account);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(AccountErrors.FailUpdateProfile);
        }      
        public async Task<dynamic> GetProfileByIdBasedOnRole(int id)
        {

            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                return Result.Failure(AccountErrors.FailGetProfile);
            }
            else
            {
                if (account.RoleId == 3)
                {
                    ProfileDTO profile = new ProfileDTO()
                    {
                        Email = account.Email,
                        Address = account.Address,
                        Birthday = account.Birthday,
                        Phone = account.Phone,
                        Avatar = account.Avatar,
                        Name = account.Name
                    };
                    return Result.SuccessWithObject(profile);
                }
                if (account.RoleId == 4)
                {
                    var tutorAccount = await _unitOfWork.TutorInformationRepository.GetProfile(id);
                    if (tutorAccount == null || tutorAccount.TutorInformation == null)
                    {
                        return Result.Failure(TutorErrors.FailGettingAccount);
                    }

                    var tutorProfile = _mapper.Map<TutorProfileDTO>(tutorAccount);

                    // Lấy tên danh mục
                    var tutorCategory = await _unitOfWork.TutorCategoryRepository.GetByIdAsync(tutorAccount.TutorInformation.TutorCategoryId);
                    tutorProfile.TutorCategoryName = tutorCategory.Name;

                    return Result.SuccessWithObject(tutorProfile);
                }
                return Result.Failure(TutorErrors.FailGettingAccount);
            }
        }
        public async Task<PagedResult<AllAccountDTO>> GetAllAccountsAsync(int page, int size, string? search = null, bool sortByBirthdayAsc = true)
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAccountsAsync(page: page, size: size, search: search, sortByBirthdayAsc: sortByBirthdayAsc);
            var totalItems = await _unitOfWork.AccountRepository.CountAsync(search); // Đếm tổng số tài khoản phù hợp

            return new PagedResult<AllAccountDTO>
            {
                Items = _mapper.Map<IEnumerable<AllAccountDTO>>(accounts),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / size)
            };
        }

        public async Task<PagedResult<AllTutorDTO>> GetAllAvailableTutorAsync(int page, int size, string? search = null, bool sortByBirthdayAsc = true, string flag = "")
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAvailableTutorAsync(page: page, size: size, search: search, sortByBirthdayAsc: sortByBirthdayAsc, flag: flag);
            var totalItems = await _unitOfWork.AccountRepository.CountTutorsAsync(search, flag); // Đếm tổng số gia sư phù hợp

            return new PagedResult<AllTutorDTO>
            {
                Items = _mapper.Map<IEnumerable<AllTutorDTO>>(accounts),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / size)
            };
        }


    }
}
