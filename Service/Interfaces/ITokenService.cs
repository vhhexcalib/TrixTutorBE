using Microsoft.IdentityModel.Tokens;
using Service.DTOs.TokenDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.AccountDTO;
namespace Service.Interfaces
{
    public interface ITokenService
    {
        Task<SecurityToken> GenerateTokenAsync(CurrentUserObject currentUserObject);
        Task<string> GenerateAccessTokenAsync(SecurityToken token);
    }
}
