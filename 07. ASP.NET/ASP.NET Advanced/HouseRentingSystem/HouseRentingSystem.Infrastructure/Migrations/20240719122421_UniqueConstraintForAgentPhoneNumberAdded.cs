using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintForAgentPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81333ab4-f620-4ac1-8cf3-89d0a92f38f6", "AQAAAAEAACcQAAAAEL+8LOLAIU2mqPmNmWLthz8kstkiZEu5kmbBXCWxusD4Sd3byCfsN9TZtuDHF2dkGQ==", "575e7616-d4c1-4ce6-bc01-0ccca5359928" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a24de7-0b72-4df8-a46a-7aaf36668ea5", "AQAAAAEAACcQAAAAEDZy8Ai13m/4pjqezavsvHkXNAff7WTtbf0+wiHi8MDZH47OJ0mjQDEBUUaOBi4Emg==", "3a695a45-1459-4500-b3c5-008369e65e66" });
        }
    }
}
