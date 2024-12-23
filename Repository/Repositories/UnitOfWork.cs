﻿using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrixTutorDBContext _context;
        public IAccountRepository AccountRepository { get; set; }
        public ISystemAccountRepository SystemAccountRepository { get; set; }
        public UnitOfWork(TrixTutorDBContext context)
        {
            _context = context;
            AccountRepository = new AccountRepository(_context);
            SystemAccountRepository = new SystemAccountRepository(_context);
        }
        public async Task<string> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return "Save Change Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
