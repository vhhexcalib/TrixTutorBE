﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData
                (
                new Account
                {
                    Id = 1,
                    Email = "Student@gmail.com",
                    Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", //Trixtutor@123
                    RoleId = 3,
                    IsEmailConfirm = true,
                    Address = "HCM",
                    Age = 15,
                    Phone = "1234567890",                    
                    IsBan = false
                },
                 new Account
                 {
                     Id = 2,
                     Email = "Tutor@gmail.com",
                     Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", //Trixtutor@123
                     RoleId = 4,
                     IsEmailConfirm = true,
                     Address = "HCM",
                     Age = 35,
                     Phone = "0987654321",
                     IsBan = false
                 }
                );
        }
    }
}
