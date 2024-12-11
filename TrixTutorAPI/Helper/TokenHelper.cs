using Service.DTOs.AccountDTO;
using static Azure.Core.HttpHeader;
using System.Security.Claims;
using Service.DTOs.AccountDTO;
namespace TrixTutorAPI.Helper
{
    public class TokenHelper
    {
        private static TokenHelper instance;
        public static TokenHelper Instance
        {
            get { if (instance == null) instance = new TokenHelper(); return TokenHelper.instance; }
            private set { TokenHelper.instance = value; }
        }
        public async Task<CurrentUserObject> GetThisUserInfo(HttpContext httpContext)
        {
            CurrentUserObject currentUser = new();

            var checkUser = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (checkUser != null)
            {
                var accountIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "AccountId")?.Value;
                if (int.TryParse(accountIdClaim, out int id))
                {
                    currentUser.AccountId = id;
                }
                var roleClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (int.TryParse(roleClaim, out int roleId))
                {
                    currentUser.RoleId = roleId;
                }
                else
                {
                    currentUser.RoleId = -1;
                }
                currentUser.AccountEmail = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                return currentUser;
            }
            else
            {
                return null;
            }
        }
    }
}