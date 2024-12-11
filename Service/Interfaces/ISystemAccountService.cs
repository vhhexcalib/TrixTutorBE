using Service.DTOs.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISystemAccountService 
    {
        Task<dynamic> LoginAsync(LoginDTO loginDTO);
    }
}
