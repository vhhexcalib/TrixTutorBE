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
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Renting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    LastRentingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastRentingStudent = table.Column<int>(type: "int", nullable: false),
                    LastRentingCategoryId = table.Column<int>(type: "int", nullable: false),
                    RentingStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renting_Account_LastRentingStudent",
                        column: x => x.LastRentingStudent,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renting_Account_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renting_TutorCategory_LastRentingCategoryId",
                        column: x => x.LastRentingCategoryId,
                        principalTable: "TutorCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
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
                    LowestSalaryPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HighestSalaryPerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeachingStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    MaxLearning = table.Column<int>(type: "int", nullable: false),
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
                    TeachingPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_TutorInformation_TutorId",
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
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    FeedbackContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckingRequest = table.Column<bool>(type: "bit", nullable: false),
                    AdminChecked = table.Column<bool>(type: "bit", nullable: false),
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
                    LearningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentAttendance = table.Column<bool>(type: "bit", nullable: false),
                    StudentReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false),
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
                table: "TutorCategory",
                columns: new[] { "Id", "Name", "Quantity", "RentingQuantity" },
                values: new object[,]
                {
                    { 1, "Toán học", 1, 0 },
                    { 2, "Vật lý", 1, 0 },
                    { 3, "Hóa học", 1, 0 },
                    { 4, "Sinh học", 1, 0 },
                    { 5, "Lịch sử", 1, 0 },
                    { 6, "Địa lý", 1, 0 },
                    { 7, "Ngữ văn", 1, 0 },
                    { 8, "Tâm lý học", 1, 0 },
                    { 9, "Triết học", 1, 0 },
                    { 10, "Xã hội học", 1, 0 },
                    { 11, "Luật học", 1, 0 },
                    { 12, "Tiếng Anh", 1, 0 },
                    { 13, "Tiếng Pháp", 1, 0 },
                    { 14, "Tiếng Đức", 1, 0 },
                    { 15, "Tiếng Trung", 1, 0 },
                    { 16, "Tiếng Nhật", 1, 0 },
                    { 17, "Lập trình", 1, 0 },
                    { 18, "Công nghệ thông tin", 1, 0 },
                    { 19, "Thiết kế đồ họa", 1, 0 },
                    { 20, "Âm nhạc", 1, 0 },
                    { 21, "Mỹ thuật", 1, 0 },
                    { 22, "Giáo dục thể chất", 1, 0 },
                    { 23, "Tài chính & Kinh tế", 1, 0 },
                    { 24, "Kinh doanh & Quản lý", 1, 0 },
                    { 25, "Marketing", 1, 0 },
                    { 26, "Kế toán", 1, 0 },
                    { 27, "Kỹ thuật cơ khí", 1, 0 },
                    { 28, "Kỹ thuật điện - điện tử", 1, 0 },
                    { 29, "Y học", 1, 0 },
                    { 30, "Dược học", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address", "Avatar", "Birthday", "Email", "IsBan", "IsEmailConfirm", "Name", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "HCM", "imgurl", new DateOnly(2025, 2, 26), "Student@gmail.com", false, true, "Student", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "1234567890", 3 },
                    { 2, "HCM", "imgurl", new DateOnly(2025, 2, 26), "Tutor@gmail.com", false, true, "Tutor", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "0987654321", 4 }
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
                values: new object[] { 1, 0m, 0m, new DateTime(2025, 2, 26, 17, 20, 4, 22, DateTimeKind.Local).AddTicks(559) });

            migrationBuilder.InsertData(
                table: "TutorInformation",
                columns: new[] { "TutorId", "Degree", "ExperienceYear", "GeneralProfile", "HighestSalaryPerHour", "IsPremium", "IsRented", "Language", "LowestSalaryPerHour", "MaxLearning", "TeachingStyle", "TotalTeachDay", "TutorCategoryId" },
                values: new object[] { 2, "link", "10Year", "general profile", 0m, false, false, "Vietnamese", 0m, 0, "fun", 0, 1 });

            migrationBuilder.InsertData(
                table: "BankInformation",
                columns: new[] { "TutorId", "BankName", "BankNumber", "OwnerName" },
                values: new object[] { 2, "BankName", "1234567890", "Tutor" });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_TutorId",
                table: "Certificate",
                column: "TutorId");

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
                name: "IX_Payment_AccountId",
                table: "Payment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Renting_LastRentingCategoryId",
                table: "Renting",
                column: "LastRentingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Renting_LastRentingStudent",
                table: "Renting",
                column: "LastRentingStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Renting_TutorId",
                table: "Renting",
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
                name: "IX_TutorInformation_TutorCategoryId",
                table: "TutorInformation",
                column: "TutorCategoryId");
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
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Renting");

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
                name: "SystemAccount");

            migrationBuilder.DropTable(
                name: "Courses");

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
