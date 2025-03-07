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
    public class TransactionHistoryRepository : Repository<TransactionHistory>, ITransactionHistoryRepository
    {
        private readonly TrixTutorDBContext _context;
        public TransactionHistoryRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<TransactionHistory> GetTransactionByStudentIdAsync(int id)
        {
            return await _context.TransactionHistory.FirstOrDefaultAsync(p => p.AccountId == id);
        }
        public async Task<TransactionHistory> GetTransactionById(string id)
        {
            return await _context.TransactionHistory.FirstOrDefaultAsync(p => p.TransactionId == id);
        }
        public async Task<TransactionHistory> GetTransactionByPaymentId(string id)
        {
            return await _context.TransactionHistory.FirstOrDefaultAsync(p => p.PaymentId == id);
        }
        public async Task<IEnumerable<TransactionHistory>> GetTransactionsByStudentId(int id)
        {
            return await _context.TransactionHistory
                .Where(p => p.AccountId == id)
                .Include(a => a.Account)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            IQueryable<TransactionHistory> query = _context.Set<TransactionHistory>();

            return await query.CountAsync();
        }
    }
}
