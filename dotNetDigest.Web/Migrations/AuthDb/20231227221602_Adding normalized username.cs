using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNetDigest.Web.Migrations.AuthDb
{
    public partial class Addingnormalizedusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c543566-55f9-4907-885a-be02eaac5eb1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dda1333d-a2a5-4180-9c55-62cf3d863e37", "SUPERADMIN@DOTNETDIGEST.COM", "SUPERADMIN@DOTNETDIGEST.COM", "AQAAAAEAACcQAAAAEIrxDv88BqSjF4DM0MDlJC/wSsSLhcuFcdO7BJK/9cX6RIuEvVj7NGLN9uVRrQuGcw==", "3d81565c-6754-48ce-9eba-156fe81ffcb6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c543566-55f9-4907-885a-be02eaac5eb1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81be729e-8a27-4246-b182-3c396c44935c", null, null, "AQAAAAEAACcQAAAAECb4UKGIl2AiY6jlcE9egZzufsovsjAooWP4/SEvN9eiWchXoNCHWQQbrkIx2o/yTQ==", "4cd131cc-91c8-4eb1-b6fa-30cfdbe2aa39" });
        }
    }
}
