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
    public class SystemAccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData
                (
                new SystemAccount
                {
                    Id = 1,
                    Email = "Admin@gmail.com",
                    Password = "admin@123",
                    RoleId = 1
                },
                 new SystemAccount
                 {
                     Id = 2,
                     Email = "Staff@gmail.com",
                     Password = "Staff@123",
                     RoleId = 2
                 }
                );
        }
    }
}
