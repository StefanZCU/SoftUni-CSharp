using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniquePhoneConstraintadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
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
                values: new object[] { "a986c82c-7351-41fc-80d3-72e61988eaa2", "AQAAAAIAAYagAAAAEKJ3voEaylDliiuNAr3Yr2XqxZNa5zOVPzozfqC+ijhFhzGG99h99U/YM98fa6khGQ==", "7c109604-3e47-4ec6-b10a-5e774707b096" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf70763-58ba-49b7-a637-2a8738a3bcd1", "AQAAAAIAAYagAAAAELSOYFqa10YTf127BCzWD6OSbY1rk5c9ndn1TuNUXln8pVy8Ve/pG5zuEtDSnzD0iQ==", "0ebfff66-fe1a-4685-9d43-4279ba07c62c" });
        }
    }
}
