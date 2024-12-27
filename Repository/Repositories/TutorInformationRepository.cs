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
    public class TutorInformationRepository : Repository<TutorInformation>, ITutorInformationRepository
    {
        private readonly TrixTutorDBContext _context;
        public TutorInformationRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }

    }
}
