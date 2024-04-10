using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Data.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eece6167-c732-4606-979b-af469c41dd3d", "AQAAAAEAACcQAAAAEPF/15lwithDz6lvI3zkijMlzGaHiNvP9uM++hTQ2u4Yyr7LCgZhojbJ34D5Ub9GRg==", "ad733db4-2150-41fd-99bf-7d51311053ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ade4b66-5b69-4598-ac51-35cc44a8190e", "AQAAAAEAACcQAAAAEBMwzQvKAQCeS6dUsZKEOIAiKHy5xGhQwH+KQyBTvOUcZ5N64QJRZx90icZimBAlNA==", "f5e98af4-bb54-4e90-aef0-36b179ca0ab5" });

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
                values: new object[] { "c1289f8d-3e54-4ca6-a98a-64e595023435", "AQAAAAEAACcQAAAAEDC7Cd0PmLJ8YamwInVr+FaWRWH+2zX9bmkVCv4/xpUC94xB6Tju1cXSd5gxKP7RTg==", "99956b01-bf41-4c54-b9f8-15ae7eb38398" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1472488b-171a-4af6-9178-e5a768987798", "AQAAAAEAACcQAAAAEGKwjmpA04vuQ0zTJl2JALn9ip3Qq9SoRq5jp8htK0Qy2pdb04fH0XbfYMiPogk4kw==", "db44563f-f88c-40f6-9fae-e0598caa077e" });
        }
    }
}
