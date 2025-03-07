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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly TrixTutorDBContext _context;

        public OrderRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Order> GetOrderByStudentId(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(p => p.StudentId == id && p.Status == false);
        }
        public async Task<Order> GetUnCanceledOrderByStudentId(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(p => p.StudentId == id && p.IsCanceled == false && p.Status == false);
        }
        public async Task<Order> GetOrderById(string id)
        {
            return await _context.Order
                .Include(o => o.TutorInformation)
                .Include(o => o.Course)
                .ThenInclude(td => td.TeachingDate)
                .Include(o => o.Course)
                .ThenInclude(td => td.TeachingTime)
                .Include(o => o.Account)
                .FirstOrDefaultAsync(p => p.OrderId == id);
        }
        public async Task<Order> GetOrderDetailById(string id, int studentId)
        {
            return await _context.Order
                .Include(o => o.TutorInformation)
                    .ThenInclude(ti => ti.Account)
                .Include(o => o.Course)
                .Include(o => o.Account)
                .FirstOrDefaultAsync(p => p.OrderId == id && p.StudentId == studentId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStudentId(int id)
        {
            return await _context.Order
                .Where(p => p.StudentId == id)
                .Include(o => o.Course)
                .ThenInclude(c => c.TutorInformation)
                .ThenInclude(ti => ti.Account)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            IQueryable<Order> query = _context.Set<Order>();

            return await query.CountAsync();
        }
    }
}
