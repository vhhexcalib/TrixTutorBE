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
        public static Error FailGetById => new("Get Course", "Khóa học không tồn tại.");
        public static Error AcceptCourseFail => new("Update Course", "Chấp nhận khóa học thất bại, không lưu vào được kho dữ liệu.");
        public static Error TeachDateTimeNotFound => new("Create Course", "Không tìm thấy thông tin combo ngày, giờ dạy.");
        public static Error UploadImageFail => new("Create Course", "Cập nhật ảnh bìa của khóa học thất bại.");
        public static Error WrongTypeOfImage => new("Create Course", "Loại tệp ảnh bìa không phù hợp, vui lòng chỉ chọn file ảnh.");
        public static Error OverLimitSize => new("Upload Image", "Dung lượng tệp không được vượt quá giới hạn 500MB.");
        public static Error FailGetCourseDetail => new("Get Course Detail", "Lấy thông tin khóa học thất bại.");
        public static Error DupeTeachingDate => new("Create Course", "Combo giờ dạy học đã có khóa học được tạo, vui lòng chọn giờ dạy học khác ( nếu cả 3 khung giờ đều không còn trống, vui lòng chọn combo ngày khác.");
    }
}
