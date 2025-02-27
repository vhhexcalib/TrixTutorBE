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
    public class TeachingTimeConfiguration : IEntityTypeConfiguration<TeachingTime>
    {
        public void Configure(EntityTypeBuilder<TeachingTime> builder)
        {
            builder.HasData
                (
                new TeachingTime
                {
                    Id = 1,
                    Quantity = 0,
                    TeachingTimes = "08:00 - 10:00"
                },
                 new TeachingTime
                 {
                     Id = 2,
                     Quantity = 0,
                     TeachingTimes = "13:00 - 15:00"
                 },
                 new TeachingTime
                 {
                     Id = 3,
                     Quantity = 0,
                     TeachingTimes = "18:00 - 20:00"
                 }
                );
        }
    }
}
