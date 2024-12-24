using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public static class RegisterErrors
    {
        public static Error InvalidEmail => new("Create Account", "Email has been used, please use another email");
        public static Error InvalidPhone => new("Create Account", "Phone number has been used, please use another number");


    }
}
