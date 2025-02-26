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
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasData
               (
               new Wallet
               {
                   TutorId = 2,
                   Balance = 0,
                   LastChangeAmount = 0,
                   LastChangeDate = DateTime.Now
               }
               );
        }
    }
}
