using BusinessObject;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<dynamic> LoginAsync(LoginDTO loginDTO);
        Task<bool> CheckEmailExistAsync(string email);
        Task<bool> CheckPhoneExistAsync(string phone);
        Task<dynamic> CreateAccount(RegisterAccountDTO registerAccount);
        Task<dynamic> OTPConfirmation(string otp, string email);
        Task<dynamic> ChangePassword(PasswordDTO password, CurrentUserObject currentUserObject);
        Task<dynamic> GetProfile(CurrentUserObject currentUserObject);
        Task<PagedResult<AllAccountDTO>> GetAllAccountsAsync(int page, int size, string? search = null, bool sortByBirthdayAsc = true);
        Task<dynamic> GetProfileByIdBasedOnRole(int id);
        Task<PagedResult<AllTutorDTO>> GetAllAvailableTutorAsync(int page, int size, string? search = null, bool sortByBirthdayAsc = true, string flag = "");
    }
}
