using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITutorInformationRepository : IRepository<TutorInformation>
    {
        Task<Account> GetProfile(int id);
    }
}
