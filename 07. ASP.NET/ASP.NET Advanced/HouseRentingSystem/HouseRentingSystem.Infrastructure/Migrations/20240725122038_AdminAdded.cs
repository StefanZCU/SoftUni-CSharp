using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df970208-72be-47ad-ad31-4689b09c3e4a", "AQAAAAEAACcQAAAAEF3ZbVIwMMRCLY5nVr1mq6fjvPJG+7vWHk6o7W62rzdZ2t8xVzxwOM4RwSRtbUox6Q==", "e64a4ae3-8477-455a-af43-c3f12a8698c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e813e6ef-2dcc-4e95-9932-ad678cdf005f", "AQAAAAEAACcQAAAAEDQbQnKIOSMLwGRH4zJy3pH7UmoEOh2RBxXhVYOb3f3gLEcOLBITdezWsS2scekSTg==", "9a54feb5-fde8-42d8-b31f-15d4fc06d758" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "ed9f5f96-6fdb-419b-89f6-e584e8a024c0", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAELZvAY9a8pzLDvB40ZmJ6PCEohmxPH0xPmjf+pnVgu31vvhpWWRgt3MO0DptbzdkjA==", null, false, "17470202-92dc-415c-b60c-14728b849a06", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "856a6ada-2f8a-4d21-bb07-7ca96a606f45", "AQAAAAEAACcQAAAAELWvqEnhuU5Jl+ABg11zUnNh/EqURCFrrAXqBsLNOfbheWMKEfpJehWCjjxeL+GG/g==", "5738f498-449d-49c8-aea1-bcc6de86991c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c909b86-c1a1-45e2-8ff0-d2fa06ce9812", "AQAAAAEAACcQAAAAEFvPeTZSvHIrPdx4l65zWuR3jX5q0nYUA+Auv3M6IkbsQkTtfku0zRq6yqvyg5HjOA==", "56fa100f-1fc0-4191-a57b-15918a59609c" });
        }
    }
}
