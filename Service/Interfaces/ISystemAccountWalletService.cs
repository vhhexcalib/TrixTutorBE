using Service.DTOs.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISystemAccountWalletService
    {
        Task<dynamic> GetSystemAccountWallet(CurrentUserObject currentUserObject);
    }
}
