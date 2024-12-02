using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISystemAccountRepository : IRepository<SystemAccount>
    {
        Task<SystemAccount> LoginSystemAccountAsync(string email, string password);
    }
}
