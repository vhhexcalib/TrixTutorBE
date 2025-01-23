using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class AllAccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public bool IsBan { get; set; }
        public bool IsEmailConfirm { get; set; }
    }
}
