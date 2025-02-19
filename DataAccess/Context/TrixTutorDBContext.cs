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
        public DbSet<ConfirmationOTP> ConfirmationOTP { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<TutorCategory> TutorCategory { get; set; }
        public DbSet<TutorContact> TutorContact { get; set; }
        public DbSet<TutorInformation> TutorInformation { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
        public DbSet<Wallet> Wallet { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tutor Category Configuration
            modelBuilder.ApplyConfiguration(new TutorCategoryConfiguration());

            // SystemAccount Configuration
            modelBuilder.ApplyConfiguration(new SystemAccountConfiguration());

            // Account Configuration
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            // Role Configuration
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // Tutor Information Configuration
            modelBuilder.ApplyConfiguration(new TutorInformationConfiguration());

            // Account -> Role: 1-N
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // SystemAccount -> Role: 1-N
            modelBuilder.Entity<SystemAccount>()
                .HasOne(sa => sa.Role)
                .WithMany(r => r.SystemAccounts)
                .HasForeignKey(sa => sa.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // TutorInformation -> BankInformation: 1-1
            modelBuilder.Entity<TutorInformation>()
                .HasOne(ti => ti.BankInformation)
                .WithOne(bi => bi.TutorInformation)
                .HasForeignKey<BankInformation>(bi => bi.TutorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Account -> Feedback: 1-N
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Feedbacks)
                .WithOne(f => f.Account)
                .HasForeignKey(f => f.FeedbackById);

            // TutorInformation -> Account: 1-1
            modelBuilder.Entity<Account>()
                .HasOne(a => a.TutorInformation)
                .WithOne(t => t.Account)
                .HasForeignKey<TutorInformation>(t => t.TutorId)
                .OnDelete(DeleteBehavior.Cascade);
            // Payment -> Account: N-1
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Account)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Wallet -> Account: 1-1
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.Account)
                .WithOne(a => a.Wallet)
                .HasForeignKey<Wallet>(w => w.TutorId)
                .OnDelete(DeleteBehavior.Cascade);

            // TransactionHistory -> Account: N-1
            modelBuilder.Entity<TransactionHistory>()
                .HasOne(th => th.Account)
                .WithMany(a => a.TransactionHistories)
                .HasForeignKey(th => th.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // TutorInformation -> TutorContact: 1-1
            modelBuilder.Entity<TutorContact>()
                .HasOne(tc => tc.TutorInformation)
                .WithOne(ti => ti.TutorContact)
                .HasForeignKey<TutorContact>(tc => tc.TutorId);

            // TutorInformation -> TutorCategory: N-1
            modelBuilder.Entity<TutorInformation>()
                    .HasOne(ti => ti.TutorCategory)
                    .WithMany(tc => tc.TutorInformations)
                    .HasForeignKey(ti => ti.TutorCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            // TutorInformation -> Certificate: 1-N
            modelBuilder.Entity<TutorInformation>()
                .HasMany(ti => ti.Certificates)
                .WithOne(c => c.TutorInformation)
                .HasForeignKey(c => c.TutorId);
            // Specify the precision and scale for the decimal properties
            modelBuilder.Entity<TutorInformation>()
                .Property(ti => ti.LowestSalaryPerHour)
                .HasColumnType("decimal(18, 2)"); // Precision 18, scale 2 (2 decimal places)

            modelBuilder.Entity<TutorInformation>()
                .Property(ti => ti.HighestSalaryPerHour)
                .HasColumnType("decimal(18, 2)"); // Precision 18, scale 2 (2 decimal places)

            base.OnModelCreating(modelBuilder);
        }

        //Add-Migration InitMigration -Context TrixTutorDBContext -Project DataAccess -StartupProject TrixTutorAPI -OutputDir Context/Migrations
        //Update-Database
    }
}
