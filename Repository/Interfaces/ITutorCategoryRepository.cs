using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITutorCategoryRepository : IRepository<TutorCategory>
    {
        Task<TutorCategory> GetTutorCategoryByName(string name);
    }
}
