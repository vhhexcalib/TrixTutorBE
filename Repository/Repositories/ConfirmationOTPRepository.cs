using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ConfirmationOTPRepository : Repository<ConfirmationOTP>, IConfirmationOTPRepository
    {
        private readonly TrixTutorDBContext _context;

        public ConfirmationOTPRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _context.ConfirmationOTP.AnyAsync(x => x.Email == email);
        }

        public async Task<ConfirmationOTP> GetOTPByEmail(string email)
        {
            return await _context.ConfirmationOTP.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<ConfirmationOTP> GetExpiredOTPAsync()
        {
            var now = DateTime.Now;

            var expiredOTP = await _context.ConfirmationOTP
                .Where(x => now >= x.CreatedAt.AddMinutes(1))
                .FirstOrDefaultAsync();

            return expiredOTP;
        }

    }
}
