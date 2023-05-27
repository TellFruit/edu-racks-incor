using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racksincor.DAL.Migrations
{
    public partial class productisinstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("isinstock", "products");
            migrationBuilder.AddColumn<bool>(
                name: "isinstock",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "1",
                column: "concurrencystamp",
                value: "ac3a572e-3209-4c4b-a598-cec6eb89c845");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "2",
                column: "concurrencystamp",
                value: "6ad187be-394f-4de4-a794-36e4461b05fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "3",
                column: "concurrencystamp",
                value: "3dd991df-51e5-4dbf-8a7f-266a08926b09");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "concurrencystamp", "passwordhash" },
                values: new object[] { "3e0b671a-d3ee-4f68-8016-26101717307b", "AQAAAAEAACcQAAAAEM0vyGwqC4CTIwjjGdEqbTQLJpzg9toNVdVxKYWowrGR8jGQ0Uck3kku7/sl4YYgnw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("isinstock", "products");
            migrationBuilder.AddColumn<int>(
                name: "isinstock",
                table: "products",
                type: "integer",
                nullable: false
            );

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "1",
                column: "concurrencystamp",
                value: "2dacf776-4d2d-4fc4-a315-53d0164bd754");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "2",
                column: "concurrencystamp",
                value: "5daa7b18-4cc5-4397-b6b0-2b06c43d8682");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "3",
                column: "concurrencystamp",
                value: "46331a93-f2a1-4c59-ad46-7297ab47f13b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "concurrencystamp", "passwordhash" },
                values: new object[] { "21c090e0-2efe-4f42-8513-1c6d3aa315b7", "AQAAAAEAACcQAAAAEL8ISNjArgU7vuJ44RE7L0UTYx0Z87yNVJwXlCbmL6q/9gF1Fdwvk8K57mmr6zgcLQ==" });
        }
    }
}
