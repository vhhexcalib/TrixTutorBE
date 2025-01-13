﻿using BusinessObject;
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
                new TutorCategory
                {
                    Id = 1,
                    Name = "Toan hoc",
                    Quantity = 1
                }
                );
        }
    }
}
