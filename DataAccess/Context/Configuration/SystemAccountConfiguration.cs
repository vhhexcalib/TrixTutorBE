using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.Configuration
{
    public class SystemAccountConfiguration : IEntityTypeConfiguration<SystemAccount>
    {
        public void Configure(EntityTypeBuilder<SystemAccount> builder)
        {
            builder.HasData
                (
                new SystemAccount
                {
                    Id = 1,
                    Email = "Admin@gmail.com",
                    Password = "7676aaafb027c825bd9abab78b234070e702752f625b752e55e55b48e607e358", //admin@123
                    RoleId = 1,
                    IsBan = false
                },
                 new SystemAccount
                 {
                     Id = 2,
                     Email = "Staff@gmail.com",
                     Password = "b5465d786a2b98bbd4b8b798da4f86b34c52f64dc9a382b50c0fdb0f73f8baf1", //staff@123
                     RoleId = 2,
                     IsBan = false
                 }
                );
        }
    }
}
