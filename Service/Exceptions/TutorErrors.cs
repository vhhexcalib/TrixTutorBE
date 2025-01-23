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
        public static Error UploadFail => new("Upload Certificate", "Tải lên chứng chỉ không thành công");
        public static Error OverLimitSize => new("Upload Certificate", "Dung lượng tệp không được vượt quá giới hạn 500MB.");
        public static Error FailGettingAccount => new("Tutor profile", "Lấy thông tin cá nhân của giảng viên thất bại.");
        public static Error FailCreatingTutorInformation => new("Tutor information", "Tạo thông tin cá nhân của giảng viên thất bại.");
        public static Error ExistTutorInformation => new("Tutor information", "Thông tin của giảng viên đã tồn tại, vui lòng cập nhật thông tin nếu muốn thay đổi bất kì thông tin nào.");
        public static Error NoneExistTutorCategory => new("Tutor information", "Môn học giảng dạy không tồn tại, vui lòng chọn môn học cho phép giảng dạy");

    }
}
