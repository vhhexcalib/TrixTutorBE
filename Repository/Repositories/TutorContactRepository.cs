using BusinessObject;
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
    public class TutorContactRepository : Repository<TutorContact>, ITutorContactRepository
    {
        private readonly TrixTutorDBContext _context;
        public TutorContactRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
