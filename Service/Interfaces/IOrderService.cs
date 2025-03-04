using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        string RandomOrderId(int studentId, int courseId, int tutorId);
        Task<dynamic> CreateOrderAsync(CurrentUserObject currentUserObject, CreateOrderDTO createOrderDTO);
        Task<PagedResult<StudentOrderDTO>> GetAllStudentOrdersAsync(CurrentUserObject currentUserObject);
        Task<dynamic> GetOrderDetail(CurrentUserObject currentUserObject, OrderDTO orderDTO);
        Task<dynamic> CancelOrder(CurrentUserObject currentUserObject, OrderDTO orderDTO);
    }
}
