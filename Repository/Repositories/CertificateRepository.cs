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
    public class CertificateRepository: Repository<Certificate>, ICertificateRepository
    {
        private readonly TrixTutorDBContext _context;
        public CertificateRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> CheckExistCertificateByTutorID(int id)
        {

            return await _context.Certificate.AnyAsync(a => a.TutorId == id);
        }

    }
}
