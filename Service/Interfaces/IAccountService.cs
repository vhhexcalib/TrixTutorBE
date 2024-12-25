using BusinessObject;
using Service.DTOs.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
