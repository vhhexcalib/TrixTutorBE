using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Service.DTOs.TokenDTO;
using Service.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.AccountDTO;
using AutoMapper;
using BusinessObject;
namespace Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppSetting _appSettings;
        public TokenService(IUnitOfWork unitOfWork, IMapper mapper, IOptionsMonitor<AppSetting> appSetting)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSetting.CurrentValue;
        }

        public async Task<SecurityToken> GenerateTokenAsync(CurrentUserObject currentUserObject)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, currentUserObject.AccountId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, currentUserObject.RoleId.ToString()),
                    new Claim(ClaimTypes.Email, currentUserObject.AccountEmail),
                    new Claim("AccountId", currentUserObject.AccountId.ToString()),
                    new Claim("AccountName", currentUserObject.AccountName)

                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return token;
        }

        public async Task<string> GenerateAccessTokenAsync(SecurityToken token)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var accessToken = jwtTokenHandler.WriteToken(token);
            return accessToken;
        }      
    }
}
