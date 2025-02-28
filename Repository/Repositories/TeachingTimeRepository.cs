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
    public class TeachingTimeRepository : Repository<TeachingTime>, ITeachingTimeRepository
    {
        private readonly TrixTutorDBContext _context;
          public TeachingTimeRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
