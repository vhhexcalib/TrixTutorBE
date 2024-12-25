using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IConfirmationOTPRepository : IRepository<ConfirmationOTP>
    {
        Task<bool> CheckEmailExistAsync(string email);
        Task<ConfirmationOTP> GetOTPByEmail(string email);
    }
}
