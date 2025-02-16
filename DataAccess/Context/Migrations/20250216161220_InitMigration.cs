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
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorCategory_TutorCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "TutorCategory",
                        principalColumn: "Id");
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
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "BankInformation",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "Id", "Name", "ParentCategoryId", "Quantity" },
                values: new object[,]
                {
                    { 1, "Khoa học tự nhiên", null, 1 },
                    { 2, "Khoa học xã hội & Nhân văn", null, 1 },
                    { 3, "Ngoại ngữ", null, 1 },
                    { 4, "Khoa học máy tính & Công nghệ", null, 1 },
                    { 5, "Nghệ thuật & Giải trí", null, 1 },
                    { 6, "Thể thao & Sức khỏe", null, 1 },
                    { 7, "Kinh tế & Kinh doanh", null, 1 },
                    { 8, "Kỹ thuật & Công nghệ", null, 1 },
                    { 9, "Y học & Dược học", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address", "Avatar", "Birthday", "Email", "IsBan", "IsEmailConfirm", "Name", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "HCM", "imgurl", new DateOnly(2025, 2, 16), "Student@gmail.com", false, true, "Student", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "1234567890", 3 },
                    { 2, "HCM", "imgurl", new DateOnly(2025, 2, 16), "Tutor@gmail.com", false, true, "Tutor", "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "0987654321", 4 }
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
                table: "TutorCategory",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Quantity" },
                values: new object[,]
                {
                    { 10, "Toán học", 1, 1 },
                    { 11, "Vật lý", 1, 1 },
                    { 12, "Hóa học", 1, 1 },
                    { 13, "Sinh học", 1, 1 },
                    { 14, "Lịch sử", 2, 1 },
                    { 15, "Địa lý", 2, 1 },
                    { 16, "Ngữ văn", 2, 1 },
                    { 17, "Tâm lý học", 2, 1 },
                    { 18, "Triết học", 2, 1 },
                    { 19, "Xã hội học", 2, 1 },
                    { 20, "Luật học", 2, 1 },
                    { 21, "Tiếng Anh", 3, 1 },
                    { 22, "Tiếng Pháp", 3, 1 },
                    { 23, "Tiếng Đức", 3, 1 },
                    { 24, "Tiếng Trung", 3, 1 },
                    { 25, "Tiếng Nhật", 3, 1 },
                    { 26, "Lập trình", 4, 1 },
                    { 27, "Công nghệ thông tin", 4, 1 },
                    { 28, "Thiết kế đồ họa", 4, 1 },
                    { 29, "Âm nhạc", 5, 1 },
                    { 30, "Mỹ thuật", 5, 1 },
                    { 31, "Giáo dục thể chất", 6, 1 },
                    { 32, "Tài chính & Kinh tế", 7, 1 },
                    { 33, "Kinh doanh & Quản lý", 7, 1 },
                    { 36, "Kỹ thuật cơ khí", 8, 1 },
                    { 37, "Kỹ thuật điện - điện tử", 8, 1 },
                    { 38, "Y học", 9, 1 },
                    { 39, "Dược học", 9, 1 },
                    { 34, "Marketing", 33, 1 },
                    { 35, "Kế toán", 33, 1 }
                });

            migrationBuilder.InsertData(
                table: "TutorInformation",
                columns: new[] { "TutorId", "Degree", "ExperienceYear", "GeneralProfile", "HighestSalaryPerHour", "Language", "LowestSalaryPerHour", "TeachingStyle", "TotalTeachDay", "TutorCategoryId" },
                values: new object[] { 2, "link", "10Year", "general profile", 0m, "Vietnamese", 0m, "fun", 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_TutorId",
                table: "Certificate",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackById",
                table: "Feedback",
                column: "FeedbackById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemAccount_RoleId",
                table: "SystemAccount",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorCategory_ParentCategoryId",
                table: "TutorCategory",
                column: "ParentCategoryId");

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
                name: "SystemAccount");

            migrationBuilder.DropTable(
                name: "TutorContact");

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
