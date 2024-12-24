using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : Repository<Account> , IAccountRepository
    {
        private readonly TrixTutorDBContext _context;
        public AccountRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Account> LoginAsync(string email, string password)
        {
            
            return await _context.Account.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _context.Account.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckPhoneExistAsync(string phone)
        {
            return await _context.Account.AnyAsync(x => x.Phone == phone);
        }

        public async Task<bool> CreateAccount(Account account)
        {
            try
            {
                await _context.Account.AddAsync(account);
                var result = await _context.SaveChangesAsync();
                return result > 0; // Returns true if changes were saved successfully
            }
            catch
            {
                return false; // Returns false if an exception occurs
            }
        }

    }
}
