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
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c8331c96-8997-46a8-b9c4-e1ed011a60b4", 0, "bd2da266-6445-45d9-b7d8-a5739536e9e5", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAELxSDV40gtAlVYjl2aIxbQBFTd+IMaej0DCkAQxKGSsmqJJNvRei5GShI+82Sr+bFQ==", null, false, "b94b317b-468d-4c25-a602-ea6cfd3c1848", false, "test@softuni.bg" });

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
                    { 1, 1, new DateTime(2023, 11, 4, 13, 23, 28, 883, DateTimeKind.Local).AddTicks(3720), "Create Android client app for the TaskBoard RESTful API", "c8331c96-8997-46a8-b9c4-e1ed011a60b4", "Android Client App" },
                    { 2, 1, new DateTime(2023, 9, 17, 13, 23, 28, 883, DateTimeKind.Local).AddTicks(3760), "Implement better styling for all public pages", "c8331c96-8997-46a8-b9c4-e1ed011a60b4", "Improve CSS styles" },
                    { 3, 2, new DateTime(2024, 3, 4, 13, 23, 28, 883, DateTimeKind.Local).AddTicks(3760), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "c8331c96-8997-46a8-b9c4-e1ed011a60b4", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 4, 4, 13, 23, 28, 883, DateTimeKind.Local).AddTicks(3770), "Implement [Create Task] page for adding new tasks", "c8331c96-8997-46a8-b9c4-e1ed011a60b4", "Create Tasks" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8331c96-8997-46a8-b9c4-e1ed011a60b4");
        }
    }
}
