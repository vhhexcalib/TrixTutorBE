using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class CategoryErrors
    {
        public static Error ExistedCategory => new("Create category", "Danh mục môn học này đã tồn tại vui lòng chọn nhập môn học khác");
        public static Error CreateCategoryFailed => new("Create category", "Danh mục môn học tạo thất bại, vui lòng tạo lại");

    }
}
