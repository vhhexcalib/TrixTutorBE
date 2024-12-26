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
                    Quantity = table.Column<int>(type: "int", nullable: false)
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
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
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
                name: "BankInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankInformation_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                table: "Account",
                columns: new[] { "Id", "Address", "Age", "Email", "IsBan", "IsEmailConfirm", "Password", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "HCM", 15, "Student@gmail.com", false, true, "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "1234567890", 3 },
                    { 2, "HCM", 35, "Tutor@gmail.com", false, true, "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", "0987654321", 4 }
                });

            migrationBuilder.InsertData(
                table: "SystemAccount",
                columns: new[] { "Id", "Email", "IsBan", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "Admin@gmail.com", false, "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", 1 },
                    { 2, "Staff@gmail.com", false, "f756011db6e966fa291176eb2426febe028835d5ee6c8d92596888cff156656c", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BankInformation_AccountId",
                table: "BankInformation",
                column: "AccountId",
                unique: true);

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
