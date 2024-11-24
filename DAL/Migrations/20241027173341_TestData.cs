using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d8aa9efb-1040-4577-862b-9d1d63eec41b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97f67df4-f9de-4ba5-9f25-94c1ebfc5834", "AQAAAAIAAYagAAAAEKzJln7V8oOp1gj6m3JB0Vz+W/BknmhIwNARSTI2TQ3acg2rPmV1+7HPDAFysJSUvA==", "c4811474-0f3d-44eb-bd7f-b6d707b8c317" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demos");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc2783f2-ffeb-4bca-a601-5ae9fea07408", "AQAAAAIAAYagAAAAEB8f6GbOV3a+ww6ujv/+wpbH5SPlTSF0Kdlshxvwpwr/AjuwP8eltsJEn4h2QlBevg==", "87cd730f-b9c7-49d9-b69d-846813deac40" });
        }
    }
}
