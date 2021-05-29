using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DbSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "2cda61f5-c48b-415f-84f3-00a77b9dd019", "Guest", "GUEST" },
                    { 2, "112fdfdf-7504-4f9c-bfdd-02d2c1d0380d", "Registered", "REGISTERED" },
                    { 3, "8b9f4b36-2db6-4a5d-b28d-f588f23da310", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a27c251e-64a3-4b3e-ac74-ef1c62ab7b7d", "johnDoe@gmail.com", false, "John", "Doe", false, null, null, null, null, null, false, null, false, null },
                    { 2, 0, "782d47ae-65e7-47b8-921d-057c546b4fc0", "STlee@gmail.com", false, "Steve", "Lee", false, null, null, null, null, null, false, null, false, null },
                    { 3, 0, "c353e4fa-09fe-44d9-9248-d23abe09e07f", "admin@gmail.com", true, "Admin", "Stepanovych", false, null, null, null, null, null, false, null, false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
