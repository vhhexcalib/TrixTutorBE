using Service.DTOs.AccountDTO;
using Service.DTOs.BankDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBankInformationService
    {
        Task<dynamic> UpdateBankInformation(CurrentUserObject currentUserObject, UpdateBankInformationDTO updateBankInformationDTO);
    }
}
