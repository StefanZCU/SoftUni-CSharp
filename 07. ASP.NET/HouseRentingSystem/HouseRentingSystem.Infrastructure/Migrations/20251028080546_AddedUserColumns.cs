using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7658abdb-0e91-4c30-9e8b-41677f2a09a1", "John", "Doe", "AQAAAAIAAYagAAAAEIm8PVGT1CgZcxxM8DkR16XCT6SN0JBTUbY+VNp27V0/BhvRqD5lOZTjps/SEBo8tg==", "65477f05-f9b6-4de4-8fcb-7c2485401911" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4acc5ec2-fc24-4762-b181-7393b231a9b1", "Linda", "Michaels", "AQAAAAIAAYagAAAAECpOYOCpcc97js7rJ8veWnZAzAcfEyTUcx3X8LJ9w2scmkgcE9gZnnp7Ae2mQs276Q==", "09b57010-654f-4131-b821-86211e127759" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8b25f0d-3c10-42a2-9839-6d527785c915", "AQAAAAIAAYagAAAAEIvp961phVsXpuFm840LAcPBE0IWUtoZ8XDibZkhUJwignN1+K23nFm26jl+6YvR6g==", "b4ea0c20-6a6a-439b-a948-e24ea4bfc23a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec28ddcf-ebe9-448d-99b0-f7a0f1da6977", "AQAAAAIAAYagAAAAEEloWjn3QbViIYzhuNguTl4xKv1jbVJEw2l6X4uvQbvYCMzRSDMQiPkT73Un78HjZA==", "a244078c-d791-43d0-ab8b-1dd4d7d1f773" });
        }
    }
}
