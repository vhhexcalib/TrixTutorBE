using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> LoginAsync(string email, string password);
        Task<Account> GetAccountByEmail(string email);
        Task<bool> CheckEmailExistAsync(string email);
        Task<bool> CheckPhoneExistAsync(string phone);
        Task<bool> CreateAccount(Account account);
    }
}
