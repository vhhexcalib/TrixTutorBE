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
    }
}
