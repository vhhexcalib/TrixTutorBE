using BusinessObject;
using DataAccess.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public DbSet<SystemAccount> SystemAccount { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new SystemAccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

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

            modelBuilder.Entity<SystemAccount>()
                .HasOne(sa => sa.Role)
                .WithMany(r => r.SystemAccounts)
                .HasForeignKey(sa => sa.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        //Add-Migration InitMigration -Context TrixTutorDBContext -Project DataAccess -StartupProject TrixTutorAPI -OutputDir Context/Migrations      
        //Update-Database
    }
}
