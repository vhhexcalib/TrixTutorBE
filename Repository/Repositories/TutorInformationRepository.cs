using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TutorInformationRepository : Repository<TutorInformation>, ITutorInformationRepository
    {
        private readonly TrixTutorDBContext _context;
        public TutorInformationRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Account> GetProfile(int id)
        {
            var profile = await _context.Account
                .Include(a => a.TutorInformation)
                    .ThenInclude(ti => ti.BankInformation) // Include luôn danh mục thông tin ngân hàng
                .Include(a => a.TutorInformation)
                    .ThenInclude(ti => ti.TutorCategory) // Include luôn danh mục gia sư
                .FirstOrDefaultAsync(a => a.Id == id);

            return profile;
        }
    }
}
