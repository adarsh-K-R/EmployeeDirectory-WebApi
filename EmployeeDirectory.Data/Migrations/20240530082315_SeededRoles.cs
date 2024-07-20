using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeDirectory.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15c86807-752e-4428-ba22-9c951a1ae1c8", null, "Admin", "ADMIN" },
                    { "6a9fafe7-33f9-406a-b741-dc2e2d55c1fa", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15c86807-752e-4428-ba22-9c951a1ae1c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a9fafe7-33f9-406a-b741-dc2e2d55c1fa");
        }
    }
}
