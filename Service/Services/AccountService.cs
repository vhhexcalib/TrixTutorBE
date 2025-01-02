﻿using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Common;
using Service.DTOs.AccountDTO;
using Service.DTOs.TokenDTO;
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
                if(!account.IsEmailConfirm) return Result.Failure(LoginErrors.AccountUnverified);
                var currentUser = _mapper.Map<CurrentUserObject>(account);
                currentUser.AccountEmail = account.Email;
                currentUser.AccountId = account.Id;
                currentUser.RoleId = account.RoleId;
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
            createdAccount.Password =  await HassPassword.HassPass(registerAccount.Password);
            createdAccount.IsEmailConfirm = false;
            createdAccount.IsBan = false;
            createdAccount.RoleId = 3;
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
            var otpfounded= await _unitOfWork.ConfirmationOTPRepository.GetOTPByEmail(email);
            if (otpfounded != null)
            {
                if(otpfounded.OTP == otp)
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
                account.Password = await HassPassword.HassPass(password.Password);
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
                Age = account.Age,
                Phone = account.Phone,
                Avatar = account.Avatar
            };
            return Result.SuccessWithObject(profile);
        }

    }
}
