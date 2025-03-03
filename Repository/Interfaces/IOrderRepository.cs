using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderById(string id);
        Task<Order> GetOrderByStudentId(int id);
        Task<IEnumerable<Order>> GetOrdersByStudentId(int id);
        Task<int> CountAsync();
    }
}
