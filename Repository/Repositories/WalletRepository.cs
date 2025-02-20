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
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        private readonly TrixTutorDBContext _context;
        public WalletRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
