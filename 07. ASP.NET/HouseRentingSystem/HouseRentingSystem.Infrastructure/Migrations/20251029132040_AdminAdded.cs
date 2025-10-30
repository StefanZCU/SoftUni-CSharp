using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd878a9-f23f-4193-bca3-d6311f61c0fa", "AQAAAAIAAYagAAAAEB0CFr0kN9f0CHMP5CeVqD+ruS+uCcY7uw4ir9NGIaogKN+t8LbZCRfclf/Rgpu6cw==", "301af611-d005-497e-8106-b120acf68fd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85316ff5-f241-43f5-be94-55fdddc2731b", "AQAAAAIAAYagAAAAEIEHzSIqH+p4cqrJJuAjgxXdTJpWXGvEp4TsYDOBHTDo+CIhyKxbeIRU6Ohmaho34Q==", "865a6051-acf3-4ecf-a6a6-30d6aabfc56f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "7fdd10f7-9b00-41dd-b361-2fdd23bdca65", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEOt9/hxGftu2gf2SkYmzhTXKALLfsxuUKl0rqPQBzXV4jj45QcoabgdS5UIttRB2zQ==", null, false, "c5d1ba1d-9c44-4e97-9911-6daed91e5407", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 5, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7658abdb-0e91-4c30-9e8b-41677f2a09a1", "AQAAAAIAAYagAAAAEIm8PVGT1CgZcxxM8DkR16XCT6SN0JBTUbY+VNp27V0/BhvRqD5lOZTjps/SEBo8tg==", "65477f05-f9b6-4de4-8fcb-7c2485401911" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4acc5ec2-fc24-4762-b181-7393b231a9b1", "AQAAAAIAAYagAAAAECpOYOCpcc97js7rJ8veWnZAzAcfEyTUcx3X8LJ9w2scmkgcE9gZnnp7Ae2mQs276Q==", "09b57010-654f-4131-b821-86211e127759" });
        }
    }
}
