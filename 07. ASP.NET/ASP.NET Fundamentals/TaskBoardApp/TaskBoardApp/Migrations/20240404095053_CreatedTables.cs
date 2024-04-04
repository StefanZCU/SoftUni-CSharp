using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ecbf779f-ad19-47ee-b84a-54f81cca521b", 0, "ee21e18c-2232-4f64-9855-5ae6ff80c41f", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEGunYhFb9ba25rXhqp/O2ocXYIsEXbJ3AWlMx6vyNMXKGg1f5vxplhhl4zvHt+KPyg==", null, false, "03e587e2-136b-4e5e-8a19-e380b269f98c", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 4, 12, 50, 53, 388, DateTimeKind.Local).AddTicks(5480), "Create Android client app for the TaskBoard RESTful API", "ecbf779f-ad19-47ee-b84a-54f81cca521b", "Android Client App", null },
                    { 2, 1, new DateTime(2023, 9, 17, 12, 50, 53, 388, DateTimeKind.Local).AddTicks(5510), "Implement better styling for all public pages", "ecbf779f-ad19-47ee-b84a-54f81cca521b", "Improve CSS styles", null },
                    { 3, 2, new DateTime(2024, 3, 4, 12, 50, 53, 388, DateTimeKind.Local).AddTicks(5520), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "ecbf779f-ad19-47ee-b84a-54f81cca521b", "Desktop Client App", null },
                    { 4, 3, new DateTime(2023, 4, 4, 12, 50, 53, 388, DateTimeKind.Local).AddTicks(5520), "Implement [Create Task] page for adding new tasks", "ecbf779f-ad19-47ee-b84a-54f81cca521b", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecbf779f-ad19-47ee-b84a-54f81cca521b");
        }
    }
}
