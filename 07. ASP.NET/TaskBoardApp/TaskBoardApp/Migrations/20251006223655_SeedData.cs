using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskBoardApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Board ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Board Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Task Name"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Task Description"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of creation"),
                    BoardId = table.Column<int>(type: "int", nullable: true, comment: "Board ID"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Application user ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Board tasks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32a19f57-0fa5-4e46-8d94-a6d3982d2432", 0, "f769b46c-6049-4c9e-8bb7-5018f740cc05", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEFc++rQiLhixng0NA4LONNOrAFxiiSq2L0rotnJJquZTFoKk9HpugvWxJkE73grmug==", null, false, "e2593410-c4f7-487f-8b93-68facc870ba9", false, "test@softuni.bg" });

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
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 21, 1, 36, 55, 256, DateTimeKind.Local).AddTicks(2550), "Implement better styling for all public pages", "32a19f57-0fa5-4e46-8d94-a6d3982d2432", "Improve CSS styles" },
                    { 2, 1, new DateTime(2025, 5, 7, 1, 36, 55, 256, DateTimeKind.Local).AddTicks(2600), "Create Android client app for the TaskBoard RESTful API", "32a19f57-0fa5-4e46-8d94-a6d3982d2432", "Android Client App" },
                    { 3, 2, new DateTime(2025, 9, 7, 1, 36, 55, 256, DateTimeKind.Local).AddTicks(2610), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "32a19f57-0fa5-4e46-8d94-a6d3982d2432", "Desktop Client App" },
                    { 4, 3, new DateTime(2024, 10, 7, 1, 36, 55, 256, DateTimeKind.Local).AddTicks(2610), "Implement [Create Task] page for adding new tasks", "32a19f57-0fa5-4e46-8d94-a6d3982d2432", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a19f57-0fa5-4e46-8d94-a6d3982d2432");
        }
    }
}
