using Service.DTOs.AccountDTO;
using Service.DTOs.TutorContactDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITutorContactService
    {
        Task<dynamic> CreateContactInformation(CurrentUserObject currentUserObject, CreateContactDTO createContactDTO);
        Task<dynamic> GetContactById(CurrentUserObject currentUserObject);
    }
}
