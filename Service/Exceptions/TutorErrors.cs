using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public static class TutorErrors
    {
        public static Error UploadFail => new("Upload Certificate", "The certificate upload fail");
        public static Error OverLimitSize => new("Upload Certificate", "File size can not exceeds the 500MB limit.");
        public static Error FailGettingAccount => new("Tutor profile", "Lấy thông tin cá nhân của giảng viên thất bại");
    }
}
