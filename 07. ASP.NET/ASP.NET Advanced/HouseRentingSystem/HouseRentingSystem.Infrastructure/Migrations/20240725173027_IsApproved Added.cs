using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is house approved by admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ac9f9d-f3d2-4c0f-ac28-0151313265cb", "AQAAAAEAACcQAAAAEKomwq7lJWbxx3WFs9frkTB2KVHCUfj7L7I4t7tP3hWs5uu12TbdqNn0xNGMOVMSRg==", "ebf14b9f-a692-4c37-a1e8-1acf30c0489d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe12c5b-7729-40a1-8303-bee1a5a30dfd", "AQAAAAEAACcQAAAAEEZbxnosLyFVqBcuaMZNWHNHJNOdtwdxO0AVKbFc4w5XusX8967KD/Z0UsBvfrksKA==", "effd14b4-f9cb-41a9-9c43-a3f154f93b61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "657b12cb-7051-447f-bd72-399d2977237f", "AQAAAAEAACcQAAAAEC2GvDZaaKjjZOEkycSoZnN2kZbcPcPdp/AjfV9tFgqu2ZHRWJQR/r/x2EQ6yF/+QQ==", "4d614a36-573e-45c8-a0d7-9db2bde2d77c" });
        }

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
                values: new object[] { "df970208-72be-47ad-ad31-4689b09c3e4a", "AQAAAAEAACcQAAAAEF3ZbVIwMMRCLY5nVr1mq6fjvPJG+7vWHk6o7W62rzdZ2t8xVzxwOM4RwSRtbUox6Q==", "e64a4ae3-8477-455a-af43-c3f12a8698c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed9f5f96-6fdb-419b-89f6-e584e8a024c0", "AQAAAAEAACcQAAAAELZvAY9a8pzLDvB40ZmJ6PCEohmxPH0xPmjf+pnVgu31vvhpWWRgt3MO0DptbzdkjA==", "17470202-92dc-415c-b60c-14728b849a06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e813e6ef-2dcc-4e95-9932-ad678cdf005f", "AQAAAAEAACcQAAAAEDQbQnKIOSMLwGRH4zJy3pH7UmoEOh2RBxXhVYOb3f3gLEcOLBITdezWsS2scekSTg==", "9a54feb5-fde8-42d8-b31f-15d4fc06d758" });
        }
    }
}
