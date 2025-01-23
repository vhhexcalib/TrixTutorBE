using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class CertificateErrors
    {
        public static Error ExistedCertificate => new("Upload Certificate", "Chứng chỉ này đã được tải lên. Vui lòng chỉnh sửa chứng chỉ để thay đổi.");
        public static Error UploadFail => new("Upload Certificate", "Tải lên chứng chỉ không thành công.");
        public static Error SaveUploadFail => new("Upload Certificate", "Lưu chứng chỉ đã tải lên không thành công.");
        public static Error SaveManyUploadFail => new("Upload Certificate", "Lưu nhiều chứng chỉ tải lên không thành công.");
        public static Error FailProcess => new("Upload Certificate", "Xử lý chứng chỉ không thành công.");
        public static Error OverLimitSize => new("Upload Certificate", "Dung lượng tệp không được vượt quá giới hạn 500MB.");
        public static Error FailGetCertificatesByTutorId => new("Get Certificates", "Giảng viên chưa upload chứng chỉ.");

    }
}
