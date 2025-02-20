using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankInformation",
                columns: new[] { "TutorId", "BankName", "BankNumber", "OwnerName" },
                values: new object[] { 2, "BankName", "1234567890", "Tutor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankInformation",
                keyColumn: "TutorId",
                keyValue: 2);
        }
    }
}
