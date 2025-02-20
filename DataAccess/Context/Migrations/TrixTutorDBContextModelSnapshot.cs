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

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Avatar = "imgurl",
                            Birthday = new DateOnly(2025, 2, 19),
                            Email = "Student@gmail.com",
                            IsBan = false,
                            IsEmailConfirm = true,
                            Name = "Student",
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            Phone = "1234567890",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 2,
                            Address = "HCM",
                            Avatar = "imgurl",
                            Birthday = new DateOnly(2025, 2, 19),
                            Email = "Tutor@gmail.com",
                            IsBan = false,
                            IsEmailConfirm = true,
                            Name = "Tutor",
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            Phone = "0987654321",
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("BusinessObject.BankInformation", b =>
                {
                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorId");

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

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("UploadedAt")
                        .HasColumnType("date");

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

            modelBuilder.Entity("BusinessObject.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.HasIndex("AccountId");

                    b.ToTable("Payment");
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Name = "Admin",
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "Staff@gmail.com",
                            IsBan = false,
                            Name = "Tutor",
                            Password = "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("BusinessObject.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("TransactionHistory");
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Toán học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vật lý",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hóa học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sinh học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lịch sử",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Địa lý",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ngữ văn",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tâm lý học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 9,
                            Name = "Triết học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 10,
                            Name = "Xã hội học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 11,
                            Name = "Luật học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 12,
                            Name = "Tiếng Anh",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 13,
                            Name = "Tiếng Pháp",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 14,
                            Name = "Tiếng Đức",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 15,
                            Name = "Tiếng Trung",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 16,
                            Name = "Tiếng Nhật",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 17,
                            Name = "Lập trình",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 18,
                            Name = "Công nghệ thông tin",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 19,
                            Name = "Thiết kế đồ họa",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 20,
                            Name = "Âm nhạc",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 21,
                            Name = "Mỹ thuật",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 22,
                            Name = "Giáo dục thể chất",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 23,
                            Name = "Tài chính & Kinh tế",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 24,
                            Name = "Kinh doanh & Quản lý",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 25,
                            Name = "Marketing",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 26,
                            Name = "Kế toán",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 27,
                            Name = "Kỹ thuật cơ khí",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 28,
                            Name = "Kỹ thuật điện - điện tử",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 29,
                            Name = "Y học",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 30,
                            Name = "Dược học",
                            Quantity = 1
                        });
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

                    b.HasData(
                        new
                        {
                            TutorId = 2,
                            Degree = "link",
                            ExperienceYear = "10Year",
                            GeneralProfile = "general profile",
                            HighestSalaryPerHour = 0m,
                            Language = "Vietnamese",
                            LowestSalaryPerHour = 0m,
                            TeachingStyle = "fun",
                            TotalTeachDay = 0,
                            TutorCategoryId = 1
                        });
                });

            modelBuilder.Entity("BusinessObject.Wallet", b =>
                {
                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LastChangeAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TutorId");

                    b.ToTable("Wallet");
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
                    b.HasOne("BusinessObject.TutorInformation", "TutorInformation")
                        .WithOne("BankInformation")
                        .HasForeignKey("BusinessObject.BankInformation", "TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TutorInformation");
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

            modelBuilder.Entity("BusinessObject.Payment", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany("Payments")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
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

            modelBuilder.Entity("BusinessObject.TransactionHistory", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");
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

            modelBuilder.Entity("BusinessObject.Wallet", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithOne("Wallet")
                        .HasForeignKey("BusinessObject.Wallet", "TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Payments");

                    b.Navigation("TransactionHistories");

                    b.Navigation("TutorInformation")
                        .IsRequired();

                    b.Navigation("Wallet")
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
                    b.Navigation("BankInformation")
                        .IsRequired();

                    b.Navigation("Certificates");

                    b.Navigation("TutorContact")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
