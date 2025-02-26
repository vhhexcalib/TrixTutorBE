using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class walletConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemAccountWallet",
                keyColumn: "AccountId",
                keyValue: 1,
                column: "LastChangeDate",
                value: new DateTime(2025, 2, 26, 17, 48, 38, 811, DateTimeKind.Local).AddTicks(9571));

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "TutorId", "Balance", "LastChangeAmount", "LastChangeDate" },
                values: new object[] { 2, 0m, 0m, new DateTime(2025, 2, 26, 17, 48, 38, 811, DateTimeKind.Local).AddTicks(9649) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "TutorId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "SystemAccountWallet",
                keyColumn: "AccountId",
                keyValue: 1,
                column: "LastChangeDate",
                value: new DateTime(2025, 2, 26, 17, 20, 4, 22, DateTimeKind.Local).AddTicks(559));
        }
    }
}
