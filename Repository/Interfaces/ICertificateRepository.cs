using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICertificateRepository : IRepository<Certificate>
    {
        Task<bool> CheckExistCertificateByTutorID(int id);
    }
}
