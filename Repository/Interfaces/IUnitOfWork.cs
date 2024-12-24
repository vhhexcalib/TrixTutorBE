using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        ISystemAccountRepository SystemAccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task<string> SaveAsync();
    }
}
