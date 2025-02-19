using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorCategory_TutorCategory_ParentCategoryId",
                table: "TutorCategory");

            migrationBuilder.DropIndex(
                name: "IX_TutorCategory_ParentCategoryId",
                table: "TutorCategory");

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "TutorCategory");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateOnly(2025, 2, 19));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateOnly(2025, 2, 19));

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Toán học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Vật lý");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hóa học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Sinh học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Lịch sử");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Địa lý");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Ngữ văn");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Tâm lý học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Triết học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Xã hội học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Luật học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Tiếng Anh");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Tiếng Pháp");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Tiếng Đức");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Tiếng Trung");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Tiếng Nhật");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Lập trình");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Công nghệ thông tin");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Thiết kế đồ họa");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Âm nhạc");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Mỹ thuật");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Giáo dục thể chất");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Tài chính & Kinh tế");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Kinh doanh & Quản lý");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Marketing");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Kế toán");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Kỹ thuật cơ khí");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Kỹ thuật điện - điện tử");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Y học");

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Dược học");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "TutorCategory",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateOnly(2025, 2, 16));

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateOnly(2025, 2, 16));

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Khoa học tự nhiên", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Khoa học xã hội & Nhân văn", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Ngoại ngữ", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Khoa học máy tính & Công nghệ", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Nghệ thuật & Giải trí", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Thể thao & Sức khỏe", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Kinh tế & Kinh doanh", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Kỹ thuật & Công nghệ", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Y học & Dược học", null });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Toán học", 1 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Vật lý", 1 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Hóa học", 1 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Sinh học", 1 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Lịch sử", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Địa lý", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Ngữ văn", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Tâm lý học", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Triết học", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Xã hội học", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Luật học", 2 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Tiếng Anh", 3 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Tiếng Pháp", 3 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Tiếng Đức", 3 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Tiếng Trung", 3 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Tiếng Nhật", 3 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Lập trình", 4 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Công nghệ thông tin", 4 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Thiết kế đồ họa", 4 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Âm nhạc", 5 });

            migrationBuilder.UpdateData(
                table: "TutorCategory",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "ParentCategoryId" },
                values: new object[] { "Mỹ thuật", 5 });

            migrationBuilder.InsertData(
                table: "TutorCategory",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Quantity" },
                values: new object[,]
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_TutorCategory_ParentCategoryId",
                table: "TutorCategory",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorCategory_TutorCategory_ParentCategoryId",
                table: "TutorCategory",
                column: "ParentCategoryId",
                principalTable: "TutorCategory",
                principalColumn: "Id");
        }
    }
}
