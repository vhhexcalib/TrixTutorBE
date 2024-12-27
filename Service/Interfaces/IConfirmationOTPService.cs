using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IConfirmationOTPService
    {
        Task<bool> CheckEmailExistAsync(string email);
        Task<dynamic> GetOTPs();
    }
}
