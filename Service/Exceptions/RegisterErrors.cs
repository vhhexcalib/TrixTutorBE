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
        public static Error InvalidEmail => new("Create Account", "Email đã được sử dụng, vui lòng sử dụng email khác");
        public static Error InvalidPhone => new("Create Account", "Số điện thoại đã được sử dụng, vui lòng sử dụng số khác");
        public static Error FailCreating => new("Create Account", "Tài khoản chưa được tạo thành công");



    }
}
