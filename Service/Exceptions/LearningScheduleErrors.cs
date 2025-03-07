﻿using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class LearningScheduleErrors
    {
        public static Error FailSavingSchedule => new("Save schedule", "Lưu lịch học không thành công.");
        public static Error ScheduleNotFound => new("Get schedule", "Lịch học không tồn tại.");
        public static Error FailTakingAttendance => new("Take Attendance", "Lưu điểm danh không thành công.");
        public static Error TutorAlreadyTakenAttendance => new("Take Attendance", "Giảng viên đã được điểm danh.");
        public static Error AtleastLearnOneSlot => new("Create Feedback", "Hãy học ít nhất 1 buổi để có thể đánh giá khóa học.");


    }
}
