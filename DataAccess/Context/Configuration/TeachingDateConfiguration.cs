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

    public class TeachingDateConfiguration : IEntityTypeConfiguration<TeachingDate>
    {
        public void Configure(EntityTypeBuilder<TeachingDate> builder)
        {
            builder.HasData
                (
                new TeachingDate
                {
                    Id = 1,
                    Quantity = 0,
                    TeachingDates = "Thứ 2, Thứ 5"
                },
                 new TeachingDate
                 {
                     Id = 2,
                     Quantity = 0,
                     TeachingDates = "Thứ 3, Thứ 6"
                 },
                 new TeachingDate
                 {
                     Id = 3,
                     Quantity = 0,
                     TeachingDates = "Thứ 4, Thứ 7"
                 }
                );
        }
    }
}
