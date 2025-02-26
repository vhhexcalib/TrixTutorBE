using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task<IEnumerable<Account>> GetAllAccountsAsync(Expression<Func<Account, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByBirthdayAsc = true);
        Task<IEnumerable<Account>> GetAllAvailableTutorAsync(Expression<Func<Account, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByBirthdayAsc = true, string flag = "");
        Task<int> CountTutorsAsync(string? search = null, string flag = "");
        Task<int> CountAsync(string? search = null);
    }
}
