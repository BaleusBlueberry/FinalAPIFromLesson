using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a8d31ccc-7330-4aa3-a7e0-59d72f20fb2a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfa7e890-5551-485f-9f66-fd73ec462e78", "AQAAAAIAAYagAAAAEKR8yUppY1eKaSws3X5kBXgHoe8860YzPehWU93YU111daYzLIJn7RqpT1QI2WtMjg==", "2a0c20bf-7443-4073-8f90-156b745c76dd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
