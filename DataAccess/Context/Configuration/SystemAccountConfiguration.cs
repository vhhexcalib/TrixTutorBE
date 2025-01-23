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
                    Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", //Trixtutor@123
                    Name = "Admin",
                    RoleId = 1,
                    IsBan = false
                },
                 new SystemAccount
                 {
                     Id = 2,
                     Email = "Staff@gmail.com",
                     Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", //Trixtutor@123
                     Name = "Tutor",
                     RoleId = 2,
                     IsBan = false
                 }
                );
        }
    }
}
