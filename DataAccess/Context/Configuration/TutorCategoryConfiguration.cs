using BusinessObject;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.Configuration
{
    public class TutorCategoryConfiguration : IEntityTypeConfiguration<TutorCategory>
    {
        public void Configure(EntityTypeBuilder<TutorCategory> builder)
        {
            builder.HasData
            (
                new TutorCategory { Id = 1, Name = "Toán học", Quantity = 1 },
                new TutorCategory { Id = 2, Name = "Vật lý", Quantity = 1 },
                new TutorCategory { Id = 3, Name = "Hóa học", Quantity = 1 },
                new TutorCategory { Id = 4, Name = "Sinh học", Quantity = 1 },
                new TutorCategory { Id = 5, Name = "Lịch sử", Quantity = 1 },
                new TutorCategory { Id = 6, Name = "Địa lý", Quantity = 1 },
                new TutorCategory { Id = 7, Name = "Ngữ văn", Quantity = 1 },
                new TutorCategory { Id = 8, Name = "Tâm lý học", Quantity = 1 },
                new TutorCategory { Id = 9, Name = "Triết học", Quantity = 1 },
                new TutorCategory { Id = 10, Name = "Xã hội học", Quantity = 1 },
                new TutorCategory { Id = 11, Name = "Luật học", Quantity = 1 },
                new TutorCategory { Id = 12, Name = "Tiếng Anh", Quantity = 1 },
                new TutorCategory { Id = 13, Name = "Tiếng Pháp", Quantity = 1 },
                new TutorCategory { Id = 14, Name = "Tiếng Đức", Quantity = 1 },
                new TutorCategory { Id = 15, Name = "Tiếng Trung", Quantity = 1 },
                new TutorCategory { Id = 16, Name = "Tiếng Nhật", Quantity = 1 },
                new TutorCategory { Id = 17, Name = "Lập trình", Quantity = 1 },
                new TutorCategory { Id = 18, Name = "Công nghệ thông tin", Quantity = 1 },
                new TutorCategory { Id = 19, Name = "Thiết kế đồ họa", Quantity = 1 },
                new TutorCategory { Id = 20, Name = "Âm nhạc", Quantity = 1 },
                new TutorCategory { Id = 21, Name = "Mỹ thuật", Quantity = 1 },
                new TutorCategory { Id = 22, Name = "Giáo dục thể chất", Quantity = 1 },
                new TutorCategory { Id = 23, Name = "Tài chính & Kinh tế", Quantity = 1 },
                new TutorCategory { Id = 24, Name = "Kinh doanh & Quản lý", Quantity = 1 },
                new TutorCategory { Id = 25, Name = "Marketing", Quantity = 1 },
                new TutorCategory { Id = 26, Name = "Kế toán", Quantity = 1 },
                new TutorCategory { Id = 27, Name = "Kỹ thuật cơ khí", Quantity = 1 },
                new TutorCategory { Id = 28, Name = "Kỹ thuật điện - điện tử", Quantity = 1 },
                new TutorCategory { Id = 29, Name = "Y học", Quantity = 1 },
                new TutorCategory { Id = 30, Name = "Dược học", Quantity = 1 }
            );
        }
    }
}
