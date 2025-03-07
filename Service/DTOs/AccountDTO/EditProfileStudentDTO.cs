using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTO
{
    public class EditProfileStudentDTO
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
