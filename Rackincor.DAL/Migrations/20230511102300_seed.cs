using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racksincor.DAL.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "65d2cf05-28d8-455b-843d-d4160c64f0d8", "Admin", "ADMIN" },
                    { "2", "b47629af-730e-4e1c-bac5-721fb2361d10", "Shopper", "SHOPPER" },
                    { "3", "bfaa5397-d7cc-4b85-8bc4-10c95675acef", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShopId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "20342dd5-f76b-41e2-be9e-d01e07d7f947", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFvwTsv1NnN8dvMSq8UOarWovcK2zSyz19/8uobjksTqA/90I1qXhJm2aZdaciGPyQ==", null, false, "", 0, false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
