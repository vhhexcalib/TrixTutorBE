﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Context.Migrations
{
    [DbContext(typeof(TrixTutorDBContext))]
    partial class TrixTutorDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "HCM",
                            Age = 15,
                            Avatar = "imgurl",
                            Email = "Student@gmail.com",
                            IsBan = false,
                            IsEmailConfirm = true,
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            Phone = "1234567890",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 2,
                            Address = "HCM",
                            Age = 35,
                            Avatar = "imgurl",
                            Email = "Tutor@gmail.com",
                            IsBan = false,
                            IsEmailConfirm = true,
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            Phone = "0987654321",
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("BusinessObject.BankInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("BankInformation");
                });

            modelBuilder.Entity("BusinessObject.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Certification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("BusinessObject.ConfirmationOTP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConfirmationOTP");
                });

            modelBuilder.Entity("BusinessObject.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeedbackById")
                        .HasColumnType("int");

                    b.Property<string>("FeedbackContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalReport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackById");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("BusinessObject.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Quantity = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Quantity = 1,
                            RoleName = "Staff"
                        },
                        new
                        {
                            Id = 3,
                            Quantity = 1,
                            RoleName = "Student"
                        },
                        new
                        {
                            Id = 4,
                            Quantity = 1,
                            RoleName = "Tutor"
                        });
                });

            modelBuilder.Entity("BusinessObject.SystemAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBan")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("SystemAccount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Admin@gmail.com",
                            IsBan = false,
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Staff@gmail.com",
                            IsBan = false,
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("BusinessObject.TutorCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TutorCategory");
                });

            modelBuilder.Entity("BusinessObject.TutorContact", b =>
                {
                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<string>("FacebookURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorId");

                    b.ToTable("TutorContact");
                });

            modelBuilder.Entity("BusinessObject.TutorInformation", b =>
                {
                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExperienceYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralProfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HighestSalaryPerHour")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LowestSalaryPerHour")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("TeachingStyle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalTeachDay")
                        .HasColumnType("int");

                    b.Property<int>("TutorCategoryId")
                        .HasColumnType("int");

                    b.HasKey("TutorId");

                    b.HasIndex("TutorCategoryId");

                    b.ToTable("TutorInformation");
                });

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.HasOne("BusinessObject.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.BankInformation", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithOne("BankInformations")
                        .HasForeignKey("BusinessObject.BankInformation", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObject.Certificate", b =>
                {
                    b.HasOne("BusinessObject.TutorInformation", "TutorInformation")
                        .WithMany("Certificates")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TutorInformation");
                });

            modelBuilder.Entity("BusinessObject.Feedback", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany("Feedbacks")
                        .HasForeignKey("FeedbackById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObject.SystemAccount", b =>
                {
                    b.HasOne("BusinessObject.Role", "Role")
                        .WithMany("SystemAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.TutorContact", b =>
                {
                    b.HasOne("BusinessObject.TutorInformation", "TutorInformation")
                        .WithOne("TutorContact")
                        .HasForeignKey("BusinessObject.TutorContact", "TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TutorInformation");
                });

            modelBuilder.Entity("BusinessObject.TutorInformation", b =>
                {
                    b.HasOne("BusinessObject.TutorCategory", "TutorCategory")
                        .WithMany("TutorInformations")
                        .HasForeignKey("TutorCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusinessObject.Account", "Account")
                        .WithOne("TutorInformation")
                        .HasForeignKey("BusinessObject.TutorInformation", "TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("TutorCategory");
                });

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Navigation("BankInformations")
                        .IsRequired();

                    b.Navigation("Feedbacks");

                    b.Navigation("TutorInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessObject.Role", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("SystemAccounts");
                });

            modelBuilder.Entity("BusinessObject.TutorCategory", b =>
                {
                    b.Navigation("TutorInformations");
                });

            modelBuilder.Entity("BusinessObject.TutorInformation", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("TutorContact")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
