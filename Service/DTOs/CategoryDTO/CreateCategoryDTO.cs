using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.CategoryDTO
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Tên danh mục tối thiểu là bắt buộc.")]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯƯĂẮẶẲẴÂẦẤẬẪÇÉÈÊỀẾỆỄÌÍÒÓÔÕƠÙÚƯĂĐĩũơƯăắằẳẵâầấậẫễéèêềếệễòóôõơùúüÿýỳỵỹỶỸ\s]+$", ErrorMessage = "Tên danh mục chỉ được chứa chữ và khoảng trắng.")]
        public string CategoryName { get; set; }
    }
}
