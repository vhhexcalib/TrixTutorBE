﻿using BusinessObject;
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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly TrixTutorDBContext _context;
        public PaymentRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Payment> GetPaymentById (string id)
        {
            return await _context.Payment.FirstOrDefaultAsync(p => p.PaymentId == id);
        }
        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _context.Payment
                .Include(o => o.Order)
                .ThenInclude(o => o.Course)
                .ThenInclude(c => c.TutorInformation)
                .ThenInclude(ti => ti.Account)
                .Include(o => o.Account)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            IQueryable<Payment> query = _context.Set<Payment>();

            return await query.CountAsync();
        }
    }
}
