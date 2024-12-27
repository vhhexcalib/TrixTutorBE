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
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        private readonly TrixTutorDBContext _context;
        public FeedbackRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
