using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UserClaimsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Linda Michaels", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Teodor Lesly", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Great Admin", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0af491c-696d-4ea8-951f-07b219de6426", "AQAAAAEAACcQAAAAEBR3gG2lhU5m+lBMrrsdjPNC1dQCrZmTebRCrGBaaz5RTt6msHRvOi5Oh0l4xyDQxg==", "41db10c6-9baa-4b63-8eee-fe1ab22d56a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42bd749f-6c53-42bc-b158-fead7130f078", "AQAAAAEAACcQAAAAEAAy05t4UMvuOFuvs9SGeMadgzvaPwSn7UCO8/GXm+OoiMV0vSv+eJCu/sD1PQGJ2g==", "e15c5de3-1f4c-4692-be5e-49a442a27f80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd014675-bfb1-463a-b562-a4c5236b1a4a", "AQAAAAEAACcQAAAAEH6oc8MGIiGCfPD/9xA+33QeeSxtWL6JMiEo5lGe7RocEanYiW/JBbYSBtZa68Da3g==", "2ee8e90b-96b2-4915-9972-f8fe99245332" });
        }

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
    }
}
