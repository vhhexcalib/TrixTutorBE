using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TrixTutorDBContext : DbContext
    {
        public TrixTutorDBContext(DbContextOptions<TrixTutorDBContext> options) : base(options)
        {
        }
        #region DBSet
        public DbSet<Account> Account { get; set; }
        public DbSet<BankInformation> BankInformation { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Certificates)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountId);
            modelBuilder.Entity<Account>()
                .HasMany(a => a.BankInformations)
                .WithOne(b => b.Account)
                .HasForeignKey(b => b.AccountId); 
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
