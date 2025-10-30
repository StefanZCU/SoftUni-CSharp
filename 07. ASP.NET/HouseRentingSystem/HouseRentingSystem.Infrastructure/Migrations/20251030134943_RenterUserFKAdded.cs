using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenterUserFKAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Renter ID",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Renter ID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84074a37-8f9b-4f07-9186-93df12eb8af3", "AQAAAAIAAYagAAAAEJdfNkESNkDkFoG79yvWu7vF5gCx3VYGZ5BRB7A5rhUy6htEekGYuuFEM/MH0jhA5g==", "25be1683-72af-41fe-9ce6-fbd1b4721b70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c8f0f53-28f5-48d6-bf89-b664e6e4b41b", "AQAAAAIAAYagAAAAECB0+0k1cdFrqifBUcnA3ydQ5xoOT1U0ZNr9UawMCrJPnp7neBybqMBdNOYYKPeNLA==", "54f37259-eb8d-4090-a5a0-86ef11ba0c06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd515d09-22d6-4fff-a91a-434477391322", "AQAAAAIAAYagAAAAEMQURO9cyaXT++Gp8Xhi9LsIs276kz6Xkz26ZZQFLYEwjXkTYXxSWwRRPUekNe/wew==", "b79a8474-65b6-498a-b472-4fa92ffb4cd7" });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RenterId",
                table: "Houses",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Renter ID",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "Renter ID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "751f67df-6689-4980-83e5-3c8029bd9919", "AQAAAAIAAYagAAAAEIyux/DuU0WAjEFc569RwCONryVzKIql62g5YRFdk+KnOgshMma7WKAF/H1RpyQZkw==", "51d64b2c-85ce-43bb-80eb-a7c1b8ebb83b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad6df41c-2d9f-4dd2-904c-f85b4c9598af", "AQAAAAIAAYagAAAAEJUnJwK7J1PXEVahBfXkI8oidIv3yjOIjjSFs0DBK5Vve0IWk0ExlDkC8lsEtWItTw==", "34bee3e1-06ea-486e-9fe9-c81c4b153789" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ff73456-6d70-43f5-9ca2-ce41d303f005", "AQAAAAIAAYagAAAAEMkPaoCNuGbW9Qi9VhwicV6sekDxZgFyRWS80ZvIgaR8D0t8C8gQXAYJT0ltRJNA6A==", "d8c350d0-4efe-4b72-92e2-bbc263efc670" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");
        }
    }
}
