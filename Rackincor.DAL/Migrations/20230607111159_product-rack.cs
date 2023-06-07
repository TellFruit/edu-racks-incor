using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racksincor.DAL.Migrations
{
    public partial class productrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_racks_rackid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_racks_AspNetUsers_userid",
                table: "racks");

            migrationBuilder.DropIndex(
                name: "IX_racks_userid",
                table: "racks");

            migrationBuilder.DropIndex(
                name: "IX_products_rackid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "racks");

            migrationBuilder.DropColumn(
                name: "rackid",
                table: "products");

            migrationBuilder.CreateTable(
                name: "productrack",
                columns: table => new
                {
                    productsid = table.Column<int>(type: "integer", nullable: false),
                    racksid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productrack", x => new { x.productsid, x.racksid });
                    table.ForeignKey(
                        name: "FK_productrack_products_productsid",
                        column: x => x.productsid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productrack_racks_racksid",
                        column: x => x.racksid,
                        principalTable: "racks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rackuser",
                columns: table => new
                {
                    racksid = table.Column<int>(type: "integer", nullable: false),
                    usersid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rackuser", x => new { x.racksid, x.usersid });
                    table.ForeignKey(
                        name: "FK_rackuser_AspNetUsers_usersid",
                        column: x => x.usersid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rackuser_racks_racksid",
                        column: x => x.racksid,
                        principalTable: "racks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "1",
                column: "concurrencystamp",
                value: "9738fc80-67fe-4ecd-abba-17cdcf06cee2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "2",
                column: "concurrencystamp",
                value: "c9db713d-f299-4067-bca7-c001350ee122");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "3",
                column: "concurrencystamp",
                value: "d1ff819e-8530-4a6e-a634-3868c3c4dc97");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "id",
                keyValue: "1",
                columns: new[] { "concurrencystamp", "passwordhash" },
                values: new object[] { "b7e76df6-2f8f-4c77-8589-0caf067adf26", "AQAAAAEAACcQAAAAEIxMkicJTDWs4Fs4WpgSRmwUJciguq5+Txz7n1o1kChiYbLNz6SvTK0XyXDBav57nw==" });

            migrationBuilder.CreateIndex(
                name: "IX_productrack_racksid",
                table: "productrack",
                column: "racksid");

            migrationBuilder.CreateIndex(
                name: "IX_rackuser_usersid",
                table: "rackuser",
                column: "usersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productrack");

            migrationBuilder.DropTable(
                name: "rackuser");

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "racks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rackid",
                table: "products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_racks_userid",
                table: "racks",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_products_rackid",
                table: "products",
                column: "rackid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_racks_rackid",
                table: "products",
                column: "rackid",
                principalTable: "racks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_racks_AspNetUsers_userid",
                table: "racks",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }
    }
}
