using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class CoursesErrors
    {
        public static Error ExistCourseName => new("Create Course", "Khóa học đã tồn tại vui lòng tạo khóa học khác.");
        public static Error CreateCourseFail => new("Create Course", "Tạo khóa học thất bại không lưu vào được kho dữ liệu.");

    }
}
