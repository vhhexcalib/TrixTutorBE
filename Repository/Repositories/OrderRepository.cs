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
        public async Task<Order> GetOrderById(string id)
        {
            return await _context.Order.FirstOrDefaultAsync(p => p.OrderId == id);
        }
        public async Task<IEnumerable<Order>> GetOrdersByStudentId(int id)
        {
            return await _context.Order
                .Where(p => p.StudentId == id)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            IQueryable<Order> query = _context.Set<Order>();

            return await query.CountAsync();
        }
    }
}
