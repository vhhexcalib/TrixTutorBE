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
                    GeneralProfile = "general profile",
                    Language = "Vietnamese",
                    Degree = "link",
                    ExperienceYear = "10Year",
                    TotalTeachDay = 0,
                    CV = "link",
                    LowestSalaryPerHour = 0,
                    HighestSalaryPerHour = 0,
                    TeachingStyle = "fun",
                    TutorCategoryId = 1,
                }
                );
        }
    }
}
