using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsApprovedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is house approved by Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a6bf86c-9397-48de-9478-0f5de9fb8e8f", "AQAAAAIAAYagAAAAEJKFUSACLeXGbO30IptXWskjJtaWwt/VE4JNeQVT9v/Ajhr+n7shJ+YKbVez1G8YIQ==", "b30ab18a-738e-4e8f-b0c5-2fe224394766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea41197f-43f7-4ed3-9ce4-4b82bc0e7c4c", "AQAAAAIAAYagAAAAEGlf+2KVDQtkxYzGlGKrfEJla8RXQzsbNnjMyuibSNyRHadf6wcRdhG+cVECVkqWMg==", "2462c157-e91f-4ad3-9b6a-38fdacc115f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "effd0268-fc66-4dd5-a09a-1d5ec463c03e", "AQAAAAIAAYagAAAAEIbWqr2IihVEuaNXbZRUR3jupTOVhNB6TWvQBstxmlzjKApE4PYsBHgdND2VhDolag==", "238db901-ac60-43a1-bd5a-82055f326706" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApproved",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd878a9-f23f-4193-bca3-d6311f61c0fa", "AQAAAAIAAYagAAAAEB0CFr0kN9f0CHMP5CeVqD+ruS+uCcY7uw4ir9NGIaogKN+t8LbZCRfclf/Rgpu6cw==", "301af611-d005-497e-8106-b120acf68fd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fdd10f7-9b00-41dd-b361-2fdd23bdca65", "AQAAAAIAAYagAAAAEOt9/hxGftu2gf2SkYmzhTXKALLfsxuUKl0rqPQBzXV4jj45QcoabgdS5UIttRB2zQ==", "c5d1ba1d-9c44-4e97-9911-6daed91e5407" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85316ff5-f241-43f5-be94-55fdddc2731b", "AQAAAAIAAYagAAAAEIEHzSIqH+p4cqrJJuAjgxXdTJpWXGvEp4TsYDOBHTDo+CIhyKxbeIRU6Ohmaho34Q==", "865a6051-acf3-4ecf-a6a6-30d6aabfc56f" });
        }
    }
}
