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
    public class TutorInformationConfiguration : IEntityTypeConfiguration<TutorInformation>
    {
        public void Configure(EntityTypeBuilder<TutorInformation> builder)
        {
            builder.HasData
                (
                new TutorInformation
                {
                    TutorId = 2,
                    GeneralProfile = "Trẻ con sa mạc truyền tai nhau bài đồng giao",
                    Language = "Vietlish",
                    Degree = "Top 1 Thách Đấu",
                    ExperienceYear = "20",
                    TotalTeachDay = 0,
                    SalaryPerHour = 1000,
                    TeachingStyle = "Jungle Ăn Thịt",
                    TutorCategoryId = 1,
                    IsPremium = false,
                    IsRented = false
                }
                );
        }
    }
}
