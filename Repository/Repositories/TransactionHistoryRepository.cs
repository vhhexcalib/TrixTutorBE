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
            return await _context.TransactionHistory.FirstOrDefaultAsync(p => p.AccountId == id && p.Status == false);
        }
        public async Task<TransactionHistory> GetTransactionById(string id)
        {
            return await _context.TransactionHistory.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<TransactionHistory>> GetTransactionsByStudentId(int id)
        {
            return await _context.TransactionHistory
                .Where(p => p.AccountId == id)
                .ToListAsync();
        }
    }
}
