using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedAuthFixedV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7702e93c-c17d-4ef8-a76f-36a954ad83a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a50b0e61-28a2-4ff3-b409-91c595ae4c51", "AQAAAAIAAYagAAAAECApZK5s9WkBVBeSMO8Fpgq60yxch7w77aRqu9iduuYcYlnOT+VtSFWYcJi9jZ5yqA==", "bb6bbfb5-a78f-47e7-a090-b6d68578054a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c23ca667-9b1d-410f-a31a-403f5eeccb47");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a64eef3-13da-4d4e-9cdb-bc9e559bf7b3", "AQAAAAIAAYagAAAAEFpgcBLPmsqxdSOZOUDqTBZjawMDVaert70f8qiD1byFqCw9yZbC07qzECgNQF7cRQ==", null });
        }
    }
}
