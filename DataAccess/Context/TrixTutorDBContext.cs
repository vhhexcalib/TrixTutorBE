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
        public DbSet<LearningHistory> LearningHistory { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<LearningSchedule> LearningSchedule { get; set; }
        public DbSet<TeachingHistory> TeachingHistories { get; set; }
        public DbSet<TeachingSchedule> TeachingSchedules { get; set; }
        public DbSet<SystemAccountWallet> SystemAccountWallet { get; set; }
        public DbSet<TeachingTime> TeachingTime { get; set; }
        public DbSet<TeachingDate> TeachingDate { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Order> Order { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tutor Category Configuration
            modelBuilder.ApplyConfiguration(new TutorCategoryConfiguration());

            // SystemAccount Configuration
            modelBuilder.ApplyConfiguration(new SystemAccountConfiguration());

            // Account Configuration
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            // Role Configuration
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // Tutor Information Configuration
            modelBuilder.ApplyConfiguration(new TutorInformationConfiguration());

            // Bank Information Configuration
            modelBuilder.ApplyConfiguration(new BankInformationConfiguration());

            // System Account Wallet Configuration
            modelBuilder.ApplyConfiguration(new SystemAccountWalletConfiguration());

            // Tutor Wallet Configuration
            modelBuilder.ApplyConfiguration(new WalletConfiguration());

            // Teaching Time Configuration
            modelBuilder.ApplyConfiguration(new TeachingTimeConfiguration());

            // Teaching Date Configuration
            modelBuilder.ApplyConfiguration(new TeachingDateConfiguration());


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
                .Property(ti => ti.SalaryPerHour)
                .HasColumnType("decimal(18, 2)"); // Precision 18, scale 2 (2 decimal places)
                              
            // Payment - Cấu hình Amount
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            // TransactionHistory - Cấu hình Amount
            modelBuilder.Entity<TransactionHistory>()
                .Property(th => th.Amount)
                .HasPrecision(18, 2);

            // Wallet - Cấu hình Balance và LastChangeAmount
            modelBuilder.Entity<Wallet>()
                .Property(w => w.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Wallet>()
                .Property(w => w.LastChangeAmount)
                .HasPrecision(18, 2);
            // Account -> LearningHistory (1-N)
            modelBuilder.Entity<LearningHistory>()
                .HasOne(lh => lh.Account)
                .WithMany(a => a.LearningHistories)
                .HasForeignKey(lh => lh.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // LearningHistory -> Course (1-1)
            modelBuilder.Entity<LearningHistory>()
                .HasOne(lh => lh.Course)
                .WithOne()
                .HasForeignKey<LearningHistory>(lh => lh.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // LearningHistory -> TutorInformation (1-1)
            modelBuilder.Entity<LearningHistory>()
                .HasOne(lh => lh.TutorInformation)
                .WithOne()
                .HasForeignKey<LearningHistory>(lh => lh.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course -> TutorInformation (N-1)
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.TutorInformation)
                .WithMany(ti => ti.Courses)
                .HasForeignKey(c => c.TutorId)
                .OnDelete(DeleteBehavior.Restrict);
            // Account -> LearningSchedule (1-N)
            modelBuilder.Entity<LearningSchedule>()
                .HasOne(ls => ls.Account)
                .WithMany(a => a.LearningSchedules)
                .HasForeignKey(ls => ls.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // TutorInformation -> LearningSchedule (1-N)
            modelBuilder.Entity<LearningSchedule>()
                .HasOne(ls => ls.TutorInformation)
                .WithMany(ti => ti.LearningSchedules)
                .HasForeignKey(ls => ls.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course -> LearningSchedule (1-N)
            modelBuilder.Entity<LearningSchedule>()
                .HasOne(ls => ls.Course)
                .WithMany(c => c.LearningSchedules)
                .HasForeignKey(ls => ls.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            // Course -> TeachingHistory (1-N)
            modelBuilder.Entity<TeachingHistory>()
                .HasOne(th => th.Course)
                .WithMany(c => c.TeachingHistories)
                .HasForeignKey(th => th.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Account (Student) -> TeachingHistory (1-N)
            modelBuilder.Entity<TeachingHistory>()
                .HasOne(th => th.Account)
                .WithMany(a => a.TeachingHistories)
                .HasForeignKey(th => th.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // TutorInformation -> TeachingHistory (1-N)
            modelBuilder.Entity<TeachingHistory>()
                .HasOne(th => th.TutorInformation)
                .WithMany(ti => ti.TeachingHistories)
                .HasForeignKey(th => th.TutorId)
                .OnDelete(DeleteBehavior.Restrict);
            // Account (Student) -> TeachingSchedule (1-N)
            modelBuilder.Entity<TeachingSchedule>()
                .HasOne(ts => ts.Account)
                .WithMany(a => a.TeachingSchedules)
                .HasForeignKey(ts => ts.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // TutorInformation -> TeachingSchedule (1-N)
            modelBuilder.Entity<TeachingSchedule>()
                .HasOne(ts => ts.TutorInformation)
                .WithMany(ti => ti.TeachingSchedules)
                .HasForeignKey(ts => ts.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course -> TeachingSchedule (1-N)
            modelBuilder.Entity<TeachingSchedule>()
                .HasOne(ts => ts.Course)
                .WithMany(c => c.TeachingSchedules)
                .HasForeignKey(ts => ts.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            // Course decimal total price
            modelBuilder.Entity<Courses>()
                .Property(c => c.TotalPrice)
                .HasPrecision(18, 2);

            // SystemWallet decimal balance
            modelBuilder.Entity<SystemAccountWallet>()
                .Property(saw => saw.Balance)
                .HasPrecision(18, 2);

            // SystemWallet decimal last change amount
            modelBuilder.Entity<SystemAccountWallet>()
                .Property(saw => saw.LastChangeAmount)
                .HasPrecision(18, 2);

            // SystemWallet -> SystemAccount (1-1)
            modelBuilder.Entity<SystemAccount>()
            .HasOne(sa => sa.SystemAccountWallet)
            .WithOne(saw => saw.SystemAccount)
            .HasForeignKey<SystemAccountWallet>(saw => saw.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

            // Course -> TeachingDate (1-N)
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.TeachingDate)
                .WithMany(td => td.Courses)
                .HasForeignKey(c => c.TeachingDateId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course -> TeachingTime (1-N)
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.TeachingTime)
                .WithMany(tt => tt.Courses)
                .HasForeignKey(c => c.TeachingTimeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Report -> Account (N-1)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Account)
                .WithMany(a => a.Reports)
                .HasForeignKey(r => r.ReportById)
                .OnDelete(DeleteBehavior.Restrict);

            // Report -> TutorInformation (N-1)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.TutorInformation)
                .WithMany(ti => ti.Reports)
                .HasForeignKey(r => r.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.TutorInformation)
                .WithMany(ti => ti.Order)
                .HasForeignKey(o => o.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Course)
                .WithMany(c => c.Order)
                .HasForeignKey(o => o.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Account)
                .WithMany(a => a.Order)
                .HasForeignKey(o => o.StudentId)
                .OnDelete(DeleteBehavior.Restrict);




            base.OnModelCreating(modelBuilder);
        }

        //Add-Migration InitMigration -Context TrixTutorDBContext -Project DataAccess -StartupProject TrixTutorAPI -OutputDir Context/Migrations
        //Update-Database
    }
}
