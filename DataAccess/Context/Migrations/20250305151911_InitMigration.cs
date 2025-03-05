using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmationOTP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationOTP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachingDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TeachingDates = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachingTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TeachingTimes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentingQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsBan = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBan = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemAccount_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TutorInformation",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    GeneralProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalTeachDay = table.Column<int>(type: "int", nullable: false),
                    SalaryPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeachingStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    TutorCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorInformation", x => x.TutorId);
                    table.ForeignKey(
                        name: "FK_TutorInformation_Account_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorInformation_TutorCategory_TutorCategoryId",
                        column: x => x.TutorCategoryId,
                        principalTable: "TutorCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangeAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.TutorId);
                    table.ForeignKey(
                        name: "FK_Wallet_Account_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemAccountWallet",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangeAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAccountWallet", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_SystemAccountWallet_SystemAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "SystemAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankInformation",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankInformation", x => x.TutorId);
                    table.ForeignKey(
                        name: "FK_BankInformation_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    UploadedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeachingSlots = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeachingPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    TeachingDateId = table.Column<int>(type: "int", nullable: false),
                    TeachingTimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_TeachingDate_TeachingDateId",
                        column: x => x.TeachingDateId,
                        principalTable: "TeachingDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_TeachingTime_TeachingTimeId",
                        column: x => x.TeachingTimeId,
                        principalTable: "TeachingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminChecked = table.Column<bool>(type: "bit", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    ReportById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Account_ReportById",
                        column: x => x.ReportById,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TutorContact",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    FacebookURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorContact", x => x.TutorId);
                    table.ForeignKey(
                        name: "FK_TutorContact_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawHistory_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    FeedbackContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FeedbackById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Account_FeedbackById",
                        column: x => x.FeedbackById,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseId = table.Column<int>(type: "int", nullable: true),
                    TutorInformationTutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningHistory_Account_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LearningHistory_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningHistory_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_LearningHistory_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LearningHistory_TutorInformation_TutorInformationTutorId",
                        column: x => x.TutorInformationTutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId");
                });

            migrationBuilder.CreateTable(
                name: "LearningSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TutorAttendance = table.Column<bool>(type: "bit", nullable: false),
                    TutorReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearningTime = table.Column<int>(type: "int", nullable: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false),
                    TeachingPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningSchedule_Account_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LearningSchedule_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningSchedule_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Account_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingHistories_Account_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingHistories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingHistories_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachingSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeachingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentAttendance = table.Column<bool>(type: "bit", nullable: false),
                    StudentReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false),
                    TeachingTime = table.Column<int>(type: "int", nullable: false),
                    StudyPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingSchedules_Account_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingSchedules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachingSchedules_TutorInformation_TutorId",
                        column: x => x.TutorId,
                        principalTable: "TutorInformation",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Quantity", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 2, 1, "Staff" },
                    { 3, 1, "Student" },
                    { 4, 1, "Tutor" }
                });

            migrationBuilder.InsertData(
                table: "TeachingDate",
                columns: new[] { "Id", "Quantity", "TeachingDates" },
                values: new object[,]
                {
                    { 1, 0, "Thứ 2, Thứ 5" },
                    { 2, 0, "Thứ 3, Thứ 6" },
                    { 3, 0, "Thứ 4, Thứ 7" }
                });

            migrationBuilder.InsertData(
                table: "TeachingTime",
                columns: new[] { "Id", "Quantity", "TeachingTimes" },
                values: new object[,]
                {
                    { 1, 0, "08:00 - 10:00" },
                    { 2, 0, "13:00 - 15:00" },
                    { 3, 0, "18:00 - 20:00" }
                });

            migrationBuilder.InsertData(
                table: "TutorCategory",
                columns: new[] { "Id", "Name", "Quantity", "RentingQuantity" },
                values: new object[,]
                {
                    { 1, "Toán học", 0, 0 },
                    { 2, "Vật lý", 0, 0 },
                    { 3, "Hóa học", 0, 0 },
                    { 4, "Sinh học", 0, 0 },
                    { 5, "Lịch sử", 0, 0 },
                    { 6, "Địa lý", 0, 0 },
                    { 7, "Ngữ văn", 0, 0 },
                    { 8, "Tâm lý", 0, 0 },
                    { 9, "Triết học", 0, 0 },
                    { 10, "Xã hội", 0, 0 },
                    { 11, "Luật học", 0, 0 },
                    { 12, "Tiếng Anh", 0, 0 },
                    { 13, "Tiếng Pháp", 0, 0 },
                    { 14, "Tiếng Đức", 0, 0 },
                    { 15, "Tiếng Trung", 0, 0 },
                    { 16, "Tiếng Nhật", 0, 0 },
                    { 17, "Lập trình", 0, 0 },
                    { 18, "Công nghệ", 0, 0 },
                    { 19, "Thiết kế", 0, 0 },
                    { 20, "Âm nhạc", 0, 0 },
                    { 21, "Mỹ thuật", 0, 0 },
                    { 22, "Tài chính", 0, 0 },
                    { 23, "Kinh doanh", 0, 0 },
                    { 24, "Marketing", 0, 0 },
                    { 25, "Kế toán", 0, 0 },
                    { 26, "Cơ khí", 0, 0 },
                    { 27, "Điện tử", 0, 0 },
                    { 28, "Y học", 0, 0 },
                    { 29, "Dược học", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address", "Avatar", "Birthday", "Email", "IsBan", "IsEmailConfirm", "Name", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "HCM", "imgurl", new DateOnly(2025, 3, 5), "Student@gmail.com", false, true, "Student", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "1234567890", 3 },
                    { 2, "HCM", "https://trixtutorstorage.blob.core.windows.net/image/dae63657-5e95-456a-b31a-20f78e63d8ca.jpg", new DateOnly(2025, 3, 5), "Tutor@gmail.com", false, true, "Tutor", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "0987654321", 4 }
                });

            migrationBuilder.InsertData(
                table: "SystemAccount",
                columns: new[] { "Id", "Email", "IsBan", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "Admin@gmail.com", false, "Admin", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", 1 },
                    { 2, "Staff@gmail.com", false, "Tutor", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", 2 }
                });

            migrationBuilder.InsertData(
                table: "SystemAccountWallet",
                columns: new[] { "AccountId", "Balance", "LastChangeAmount", "LastChangeDate" },
                values: new object[] { 1, 0m, 0m, new DateTime(2025, 3, 5, 22, 19, 10, 802, DateTimeKind.Local).AddTicks(4279) });

            migrationBuilder.InsertData(
                table: "TutorInformation",
                columns: new[] { "TutorId", "Degree", "ExperienceYear", "GeneralProfile", "IsPremium", "IsRented", "Language", "SalaryPerHour", "TeachingStyle", "TotalTeachDay", "TutorCategoryId" },
                values: new object[] { 2, "Top 1 Thách Đấu", "20", "Trẻ con sa mạc truyền tai nhau bài đồng giao", false, false, "Vietlish", 1000m, "Jungle Ăn Thịt", 0, 1 });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "TutorId", "Balance", "LastChangeAmount", "LastChangeDate" },
                values: new object[] { 2, 0m, 0m, new DateTime(2025, 3, 5, 22, 19, 10, 802, DateTimeKind.Local).AddTicks(4343) });

            migrationBuilder.InsertData(
                table: "BankInformation",
                columns: new[] { "TutorId", "BankName", "BankNumber", "OwnerName" },
                values: new object[] { 2, "BankName", "1234567890", "Tutor" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreateDate", "Description", "Images", "IsAccepted", "IsLocked", "TeachingDateId", "TeachingPlace", "TeachingSlots", "TeachingTimeId", "TotalPrice", "TutorId" },
                values: new object[] { 1, "Thoát rank vàng", new DateTime(2025, 3, 5, 22, 19, 10, 802, DateTimeKind.Local).AddTicks(4559), "Faker chỉ out jungle", "courseImg", true, false, 1, "SummonerRift", 3, 1, 3000.00m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_TutorId",
                table: "Certificate",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeachingDateId",
                table: "Courses",
                column: "TeachingDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeachingTimeId",
                table: "Courses",
                column: "TeachingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TutorId",
                table: "Courses",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CourseId",
                table: "Feedback",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackById",
                table: "Feedback",
                column: "FeedbackById");

            migrationBuilder.CreateIndex(
                name: "IX_LearningHistory_CourseId",
                table: "LearningHistory",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningHistory_CoursesCourseId",
                table: "LearningHistory",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningHistory_StudentId",
                table: "LearningHistory",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningHistory_TutorId",
                table: "LearningHistory",
                column: "TutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningHistory_TutorInformationTutorId",
                table: "LearningHistory",
                column: "TutorInformationTutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningSchedule_CourseId",
                table: "LearningSchedule",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningSchedule_StudentId",
                table: "LearningSchedule",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningSchedule_TutorId",
                table: "LearningSchedule",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CourseId",
                table: "Order",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StudentId",
                table: "Order",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TutorId",
                table: "Order",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountId",
                table: "Payment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportById",
                table: "Reports",
                column: "ReportById");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_TutorId",
                table: "Reports",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemAccount_RoleId",
                table: "SystemAccount",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingHistories_CourseId",
                table: "TeachingHistories",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingHistories_StudentId",
                table: "TeachingHistories",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingHistories_TutorId",
                table: "TeachingHistories",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSchedules_CourseId",
                table: "TeachingSchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSchedules_StudentId",
                table: "TeachingSchedules",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSchedules_TutorId",
                table: "TeachingSchedules",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AccountId",
                table: "TransactionHistory",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TutorInformation_TutorCategoryId",
                table: "TutorInformation",
                column: "TutorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawHistory_TutorId",
                table: "WithdrawHistory",
                column: "TutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankInformation");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "ConfirmationOTP");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "LearningHistory");

            migrationBuilder.DropTable(
                name: "LearningSchedule");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SystemAccountWallet");

            migrationBuilder.DropTable(
                name: "TeachingHistories");

            migrationBuilder.DropTable(
                name: "TeachingSchedules");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "TutorContact");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "WithdrawHistory");

            migrationBuilder.DropTable(
                name: "SystemAccount");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "TeachingDate");

            migrationBuilder.DropTable(
                name: "TeachingTime");

            migrationBuilder.DropTable(
                name: "TutorInformation");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "TutorCategory");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
