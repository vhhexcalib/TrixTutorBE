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
    public class SystemAccountRepository : Repository<SystemAccount> , ISystemAccountRepository
    {
        private readonly TrixTutorDBContext _context;
        public SystemAccountRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<SystemAccount> LoginSystemAccountAsync(string email, string password)
        {
            return await _context.SystemAccount.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }

    }
}
