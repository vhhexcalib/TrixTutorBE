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
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);  // Secret Key

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, currentUserObject.AccountId.ToString()),  // AccountId
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, currentUserObject.AccountEmail),        // Email
            new Claim("RoleId", currentUserObject.RoleId?.ToString()),                   // RoleId
            new Claim("AccountId", currentUserObject.AccountId.ToString())
        }),
                Expires = DateTime.UtcNow.AddMinutes(30),
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

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }
    }
}
