using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedAuthFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a64eef3-13da-4d4e-9cdb-bc9e559bf7b3", "AQAAAAIAAYagAAAAEFpgcBLPmsqxdSOZOUDqTBZjawMDVaert70f8qiD1byFqCw9yZbC07qzECgNQF7cRQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", "AQAAAAIAAYagAAAAEJ+wDcEe6K5yrCMCQpw3+VRvtXvz7Tr7R8POZdyYIKl2m7GV1DHi0T8CQSotIErerQ==" });
        }
    }
}
