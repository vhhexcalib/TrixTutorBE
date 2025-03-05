using Service.DTOs.PaymentDTO;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPaymentService
    {
        Task<PagedResult<AllPaymentDTO>> GetAllPaymentAsync();
    }
}
