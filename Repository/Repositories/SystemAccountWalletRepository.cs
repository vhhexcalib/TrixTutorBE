﻿using BusinessObject;
using DataAccess.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SystemAccountWalletRepository : Repository<SystemAccountWallet>, ISystemAccountWalletRepository
    {
        private readonly TrixTutorDBContext _context;
        public SystemAccountWalletRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
