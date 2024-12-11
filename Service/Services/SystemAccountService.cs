using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
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
    public class SystemAccountService : ISystemAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public SystemAccountService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<dynamic> LoginAsync(LoginDTO loginDTO)
        {
            var logacc = _mapper.Map<SystemAccount>(loginDTO);
            string hashPassword = await HassPassword.HassPass(logacc.Password);
            var account = await _unitOfWork.SystemAccountRepository.LoginSystemAccountAsync(logacc.Email, hashPassword);
            if (account != null)
            {
                if (account.IsBan) return Result.Failure(LoginErrors.AccountIsBan);
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
    }
}
