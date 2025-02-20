using BusinessObject;
using DataAccess.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly TrixTutorDBContext _context;
        public PaymentRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
