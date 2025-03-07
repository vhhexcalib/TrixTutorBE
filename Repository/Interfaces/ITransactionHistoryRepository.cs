using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITransactionHistoryRepository : IRepository<TransactionHistory>
    {
        Task<TransactionHistory> GetTransactionByStudentIdAsync(int id);
        Task<TransactionHistory> GetTransactionById(string id);
        Task<IEnumerable<TransactionHistory>> GetTransactionsByStudentId(int id);
        Task<TransactionHistory> GetTransactionByPaymentId(string id);
        Task<int> CountAsync(int accountId);
    }
}
