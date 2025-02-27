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
        public static Error FailGetById => new("Get Course", "Tìm khóa học thất bại.");
        public static Error AcceptCourseFail => new("Update Course", "Chấp nhận khóa học thất bại, không lưu vào được kho dữ liệu.");
        public static Error TeachDateTimeNotFound => new("Create Course", "Không tìm thấy thông tin combo ngày, giờ dạy.");

    }
}
