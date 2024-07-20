using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeDirectory.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEmployeeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15c86807-752e-4428-ba22-9c951a1ae1c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a9fafe7-33f9-406a-b741-dc2e2d55c1fa");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ea225b6-6884-46b4-8b6e-b6420fddda4a", null, "User", "USER" },
                    { "fd4db0e1-d2f0-40cc-bcd2-14f14b798197", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ea225b6-6884-46b4-8b6e-b6420fddda4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd4db0e1-d2f0-40cc-bcd2-14f14b798197");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15c86807-752e-4428-ba22-9c951a1ae1c8", null, "Admin", "ADMIN" },
                    { "6a9fafe7-33f9-406a-b741-dc2e2d55c1fa", null, "User", "USER" }
                });
        }
    }
}
