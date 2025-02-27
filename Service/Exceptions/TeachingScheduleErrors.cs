using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class TeachingScheduleErrors
    {
        public static Error FailSavingSchedule => new("Save schedule", "Lưu lịch giảng dạy không thành công.");
    }
}
