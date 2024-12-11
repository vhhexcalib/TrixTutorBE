using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class CurrentUserObject
    {
        public int AccountId { get; set; }
        public string AccountEmail { get; set; }
        public int? RoleId { get; set; }

    }
}
