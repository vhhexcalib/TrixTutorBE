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
    public class SystemAccountWalletConfiguration : IEntityTypeConfiguration<SystemAccountWallet>
    {
        public void Configure(EntityTypeBuilder<SystemAccountWallet> builder)
        {
            builder.HasData
               (
               new SystemAccountWallet
               {
                   AccountId = 1,
                   Balance = 0,
                   LastChangeAmount = 0,
                   LastChangeDate = DateTime.Now
               }
               );
        }
    }
}
