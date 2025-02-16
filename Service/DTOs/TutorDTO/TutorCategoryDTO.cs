using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.TutorDTO
{
    public class TutorCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ParentCategory { get; set; } // Lưu tên danh mục cha
        public int Quantity { get; set; }
    }

}
