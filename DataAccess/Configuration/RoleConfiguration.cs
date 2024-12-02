using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
                (
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                    Quantity = 0,
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Staff",
                    Quantity = 0,
                }, 
                new Role
                {
                    Id = 3,
                    RoleName = "Student",
                    Quantity = 0,
                },
                new Role
                {
                    Id = 4,
                    RoleName = "Tutor",
                    Quantity = 0,
                },
                new Role
                {
                    Id = 5,
                    RoleName = "Parent",
                    Quantity = 0,
                }
                );
        }
    }
}
