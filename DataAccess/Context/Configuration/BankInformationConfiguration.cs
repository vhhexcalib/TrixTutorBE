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
    public class BankInformationConfiguration : IEntityTypeConfiguration<BankInformation>
    {
        public void Configure(EntityTypeBuilder<BankInformation> builder)
        {
            builder.HasData
                (
                new BankInformation
                {
                    TutorId = 2,
                    BankName = "BankName",
                    BankNumber = "1234567890",
                    OwnerName = "Tutor"
                }
                );
        }
    }
}
