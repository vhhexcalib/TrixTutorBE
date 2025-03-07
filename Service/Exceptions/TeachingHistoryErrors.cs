using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class TeachingHistoryErrors
    {
        public static Error FailCreateTeachingHistory => new("Create Teaching History", "Tạo lịch sử dạy học thất bại, không lưu vào cơ sở dữ liệu.");

    }
}
