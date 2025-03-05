using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Context.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasData(
                new Courses
                {
                    CourseId = 1,
                    CourseName = "Thoát rank vàng",
                    Description = "Faker chỉ out jungle",
                    TeachingSlots = 3,
                    TotalPrice = 3000.00m,
                    CreateDate = DateTime.Now,
                    Images = "courseImg",
                    TeachingPlace = "SummonerRift",
                    IsAccepted = true,
                    IsLocked = false,
                    TutorId = 2,
                    TeachingDateId = 1,
                    TeachingTimeId = 1
                }
            );
        }
    }
}
