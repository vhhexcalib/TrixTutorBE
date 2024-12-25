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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly TrixTutorDBContext _context;
        public RoleRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
