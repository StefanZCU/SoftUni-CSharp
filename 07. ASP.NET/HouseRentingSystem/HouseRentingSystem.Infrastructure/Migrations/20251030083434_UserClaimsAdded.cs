using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserClaimsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Agent Agentov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Guest Guestov", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Admin Adminov", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "751f67df-6689-4980-83e5-3c8029bd9919", "Guest", "Guestov", "AQAAAAIAAYagAAAAEIyux/DuU0WAjEFc569RwCONryVzKIql62g5YRFdk+KnOgshMma7WKAF/H1RpyQZkw==", "51d64b2c-85ce-43bb-80eb-a7c1b8ebb83b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad6df41c-2d9f-4dd2-904c-f85b4c9598af", "Admin", "Adminov", "AQAAAAIAAYagAAAAEJUnJwK7J1PXEVahBfXkI8oidIv3yjOIjjSFs0DBK5Vve0IWk0ExlDkC8lsEtWItTw==", "34bee3e1-06ea-486e-9fe9-c81c4b153789" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ff73456-6d70-43f5-9ca2-ce41d303f005", "Agent", "Agentov", "AQAAAAIAAYagAAAAEMkPaoCNuGbW9Qi9VhwicV6sekDxZgFyRWS80ZvIgaR8D0t8C8gQXAYJT0ltRJNA6A==", "d8c350d0-4efe-4b72-92e2-bbc263efc670" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a6bf86c-9397-48de-9478-0f5de9fb8e8f", "John", "Doe", "AQAAAAIAAYagAAAAEJKFUSACLeXGbO30IptXWskjJtaWwt/VE4JNeQVT9v/Ajhr+n7shJ+YKbVez1G8YIQ==", "b30ab18a-738e-4e8f-b0c5-2fe224394766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea41197f-43f7-4ed3-9ce4-4b82bc0e7c4c", "Great", "Admin", "AQAAAAIAAYagAAAAEGlf+2KVDQtkxYzGlGKrfEJla8RXQzsbNnjMyuibSNyRHadf6wcRdhG+cVECVkqWMg==", "2462c157-e91f-4ad3-9b6a-38fdacc115f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "effd0268-fc66-4dd5-a09a-1d5ec463c03e", "Linda", "Michaels", "AQAAAAIAAYagAAAAEIbWqr2IihVEuaNXbZRUR3jupTOVhNB6TWvQBstxmlzjKApE4PYsBHgdND2VhDolag==", "238db901-ac60-43a1-bd5a-82055f326706" });
        }
    }
}
