using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class LearningHistoryErrors
    {
        public static Error FailCreateLearningHistory => new("Create Learning History", "Tạo lịch sử học thất bại, không lưu vào cơ sở dữ liệu.");
        public static Error ScheduleNotFound => new("Get schedule", "Lịch học không tồn tại.");


    }
}
