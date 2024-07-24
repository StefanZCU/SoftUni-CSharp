using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UsersExtended : Migration
    {
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
                values: new object[] { "856a6ada-2f8a-4d21-bb07-7ca96a606f45", "Teodor", "Lesly", "AQAAAAEAACcQAAAAELWvqEnhuU5Jl+ABg11zUnNh/EqURCFrrAXqBsLNOfbheWMKEfpJehWCjjxeL+GG/g==", "5738f498-449d-49c8-aea1-bcc6de86991c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c909b86-c1a1-45e2-8ff0-d2fa06ce9812", "Linda", "Michaels", "AQAAAAEAACcQAAAAEFvPeTZSvHIrPdx4l65zWuR3jX5q0nYUA+Auv3M6IkbsQkTtfku0zRq6yqvyg5HjOA==", "56fa100f-1fc0-4191-a57b-15918a59609c" });
        }

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
                values: new object[] { "21c7e63c-d2ef-4f93-af2d-b2ae5c62a81f", "AQAAAAEAACcQAAAAEGqYaEbzq5F+fFj7SjWvnc1fdEfmryvm/Ca6gHN7px15Qz6ibFMnXP7M/dZVh2shlw==", "a0ee2d5d-65d9-4883-8f0e-3b37689bdca4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49324569-d7f7-43b4-9e1d-816db2a83e0d", "AQAAAAEAACcQAAAAEINN84U2LYac6vKlFCKcsHi3Vyk2sJfq/UP6kINMqZYTg9ZAECshUVlTpqRc4z06sg==", "25dc81f7-994e-472a-bd8f-3db5be63267f" });
        }
    }
}
