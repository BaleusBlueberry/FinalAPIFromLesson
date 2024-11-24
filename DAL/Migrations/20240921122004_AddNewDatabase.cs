using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "287660e0-dba7-4980-abbc-7e9787d8c68c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc2783f2-ffeb-4bca-a601-5ae9fea07408", "baleus@baleus.com", "AQAAAAIAAYagAAAAEB8f6GbOV3a+ww6ujv/+wpbH5SPlTSF0Kdlshxvwpwr/AjuwP8eltsJEn4h2QlBevg==", "87cd730f-b9c7-49d9-b69d-846813deac40" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfa7e890-5551-485f-9f66-fd73ec462e78", "Blaeus@Baleus.com", "AQAAAAIAAYagAAAAEKR8yUppY1eKaSws3X5kBXgHoe8860YzPehWU93YU111daYzLIJn7RqpT1QI2WtMjg==", "2a0c20bf-7443-4073-8f90-156b745c76dd" });
        }
    }
}
