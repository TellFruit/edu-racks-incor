using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racksincor.DAL.Migrations
{
    public partial class lowercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shops_ShopId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Racks_RackId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotion_Products_ProductsId",
                table: "ProductPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotion_Promotions_PromotionsId",
                table: "ProductPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Racks_RackId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Shops_ShopId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Racks_AspNetUsers_UserId",
                table: "Racks");

            migrationBuilder.DropForeignKey(
                name: "FK_Racks_Shops_ShopId",
                table: "Racks");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Products_ProductId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Devices_DeviceId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Racks_RackId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shops",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Racks",
                table: "Racks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPromotion",
                table: "ProductPromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Shops",
                newName: "shops");

            migrationBuilder.RenameTable(
                name: "Records",
                newName: "records");

            migrationBuilder.RenameTable(
                name: "Reactions",
                newName: "reactions");

            migrationBuilder.RenameTable(
                name: "Racks",
                newName: "racks");

            migrationBuilder.RenameTable(
                name: "Promotions",
                newName: "promotions");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "ProductPromotion",
                newName: "productpromotion");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "devices");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "companies");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "shops",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "shops",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "shops",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "shops",
                newName: "companyid");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "shops",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "shops",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Shops_CompanyId",
                table: "shops",
                newName: "IX_shops_companyid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "records",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "RackId",
                table: "records",
                newName: "rackid");

            migrationBuilder.RenameColumn(
                name: "EndingTime",
                table: "records",
                newName: "endingtime");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "records",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "records",
                newName: "deviceid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "records",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "BeginningTime",
                table: "records",
                newName: "beginningtime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "records",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Records_RackId",
                table: "records",
                newName: "IX_records_rackid");

            migrationBuilder.RenameIndex(
                name: "IX_Records_DeviceId",
                table: "records",
                newName: "IX_records_deviceid");

            migrationBuilder.RenameColumn(
                name: "IsPositive",
                table: "reactions",
                newName: "ispositive");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "reactions",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reactions",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ProductId",
                table: "reactions",
                newName: "IX_reactions_productid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "racks",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "racks",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "racks",
                newName: "shopid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "racks",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "racks",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "racks",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Racks_UserId",
                table: "racks",
                newName: "IX_racks_userid");

            migrationBuilder.RenameIndex(
                name: "IX_Racks_ShopId",
                table: "racks",
                newName: "IX_racks_shopid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "promotions",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "promotions",
                newName: "shopid");

            migrationBuilder.RenameColumn(
                name: "Percenatage",
                table: "promotions",
                newName: "percenatage");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "promotions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "GiftProductId",
                table: "promotions",
                newName: "giftproductid");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "promotions",
                newName: "expirationdate");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "promotions",
                newName: "discriminator");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "promotions",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "promotions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Promotions_ShopId",
                table: "promotions",
                newName: "IX_promotions_shopid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "products",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "products",
                newName: "shopid");

            migrationBuilder.RenameColumn(
                name: "RackId",
                table: "products",
                newName: "rackid");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsInStock",
                table: "products",
                newName: "isinstock");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "products",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopId",
                table: "products",
                newName: "IX_products_shopid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_RackId",
                table: "products",
                newName: "IX_products_rackid");

            migrationBuilder.RenameColumn(
                name: "PromotionsId",
                table: "productpromotion",
                newName: "promotionsid");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "productpromotion",
                newName: "productsid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPromotion_PromotionsId",
                table: "productpromotion",
                newName: "IX_productpromotion_promotionsid");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "devices",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "RackId",
                table: "devices",
                newName: "rackid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "devices",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "devices",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_RackId",
                table: "devices",
                newName: "IX_devices_rackid");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "companies",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "companies",
                newName: "updatedat");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "companies",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "companies",
                newName: "contactphone");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "companies",
                newName: "contactemail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "companies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AspNetUserTokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUserTokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                newName: "loginprovider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserTokens",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                newName: "twofactorenabled");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "AspNetUsers",
                newName: "shopid");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "AspNetUsers",
                newName: "securitystamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                newName: "phonenumberconfirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AspNetUsers",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "AspNetUsers",
                newName: "passwordhash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                newName: "normalizedusername");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                newName: "normalizedemail");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "AspNetUsers",
                newName: "lockoutend");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                newName: "lockoutenabled");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                newName: "emailconfirmed");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AspNetUsers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                newName: "accessfailedcount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ShopId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_shopid");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AspNetUserRoles",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserRoles",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_roleid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserLogins",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "AspNetUserLogins",
                newName: "providerdisplayname");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                newName: "providerkey");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                newName: "loginprovider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_userid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserClaims",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AspNetUserClaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AspNetUserClaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUserClaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_userid");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "AspNetRoles",
                newName: "normalizedname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetRoles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AspNetRoles",
                newName: "concurrencystamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AspNetRoleClaims",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AspNetRoleClaims",
                newName: "claimvalue");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AspNetRoleClaims",
                newName: "claimtype");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoleClaims",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_roleid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shops",
                table: "shops",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_records",
                table: "records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reactions",
                table: "reactions",
                columns: new[] { "userid", "productid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_racks",
                table: "racks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_promotions",
                table: "promotions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productpromotion",
                table: "productpromotion",
                columns: new[] { "productsid", "promotionsid" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_devices",
                table: "devices",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_roleid",
                table: "AspNetRoleClaims",
                column: "roleid",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_userid",
                table: "AspNetUserClaims",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_userid",
                table: "AspNetUserLogins",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_roleid",
                table: "AspNetUserRoles",
                column: "roleid",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_userid",
                table: "AspNetUserRoles",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_shops_shopid",
                table: "AspNetUsers",
                column: "shopid",
                principalTable: "shops",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_userid",
                table: "AspNetUserTokens",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_devices_racks_rackid",
                table: "devices",
                column: "rackid",
                principalTable: "racks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productpromotion_products_productsid",
                table: "productpromotion",
                column: "productsid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productpromotion_promotions_promotionsid",
                table: "productpromotion",
                column: "promotionsid",
                principalTable: "promotions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_racks_rackid",
                table: "products",
                column: "rackid",
                principalTable: "racks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_shops_shopid",
                table: "products",
                column: "shopid",
                principalTable: "shops",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_promotions_shops_shopid",
                table: "promotions",
                column: "shopid",
                principalTable: "shops",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_racks_AspNetUsers_userid",
                table: "racks",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_racks_shops_shopid",
                table: "racks",
                column: "shopid",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reactions_AspNetUsers_userid",
                table: "reactions",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reactions_products_productid",
                table: "reactions",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_records_devices_deviceid",
                table: "records",
                column: "deviceid",
                principalTable: "devices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_records_racks_rackid",
                table: "records",
                column: "rackid",
                principalTable: "racks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_shops_companies_companyid",
                table: "shops",
                column: "companyid",
                principalTable: "companies",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_roleid",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_userid",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_userid",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_roleid",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_userid",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shops_shopid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_userid",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_devices_racks_rackid",
                table: "devices");

            migrationBuilder.DropForeignKey(
                name: "FK_productpromotion_products_productsid",
                table: "productpromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_productpromotion_promotions_promotionsid",
                table: "productpromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_products_racks_rackid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_shops_shopid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_promotions_shops_shopid",
                table: "promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_racks_AspNetUsers_userid",
                table: "racks");

            migrationBuilder.DropForeignKey(
                name: "FK_racks_shops_shopid",
                table: "racks");

            migrationBuilder.DropForeignKey(
                name: "FK_reactions_AspNetUsers_userid",
                table: "reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_reactions_products_productid",
                table: "reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_records_devices_deviceid",
                table: "records");

            migrationBuilder.DropForeignKey(
                name: "FK_records_racks_rackid",
                table: "records");

            migrationBuilder.DropForeignKey(
                name: "FK_shops_companies_companyid",
                table: "shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shops",
                table: "shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_records",
                table: "records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reactions",
                table: "reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_racks",
                table: "racks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_promotions",
                table: "promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productpromotion",
                table: "productpromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_devices",
                table: "devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "shops",
                newName: "Shops");

            migrationBuilder.RenameTable(
                name: "records",
                newName: "Records");

            migrationBuilder.RenameTable(
                name: "reactions",
                newName: "Reactions");

            migrationBuilder.RenameTable(
                name: "racks",
                newName: "Racks");

            migrationBuilder.RenameTable(
                name: "promotions",
                newName: "Promotions");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "productpromotion",
                newName: "ProductPromotion");

            migrationBuilder.RenameTable(
                name: "devices",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Companies");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Shops",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Shops",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Shops",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "companyid",
                table: "Shops",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Shops",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shops",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_shops_companyid",
                table: "Shops",
                newName: "IX_Shops_CompanyId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Records",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "rackid",
                table: "Records",
                newName: "RackId");

            migrationBuilder.RenameColumn(
                name: "endingtime",
                table: "Records",
                newName: "EndingTime");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Records",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "deviceid",
                table: "Records",
                newName: "DeviceId");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Records",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "beginningtime",
                table: "Records",
                newName: "BeginningTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Records",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_records_rackid",
                table: "Records",
                newName: "IX_Records_RackId");

            migrationBuilder.RenameIndex(
                name: "IX_records_deviceid",
                table: "Records",
                newName: "IX_Records_DeviceId");

            migrationBuilder.RenameColumn(
                name: "ispositive",
                table: "Reactions",
                newName: "IsPositive");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "Reactions",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Reactions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reactions_productid",
                table: "Reactions",
                newName: "IX_Reactions_ProductId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Racks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Racks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "shopid",
                table: "Racks",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Racks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Racks",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Racks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_racks_userid",
                table: "Racks",
                newName: "IX_Racks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_racks_shopid",
                table: "Racks",
                newName: "IX_Racks_ShopId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Promotions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "shopid",
                table: "Promotions",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "percenatage",
                table: "Promotions",
                newName: "Percenatage");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Promotions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "giftproductid",
                table: "Promotions",
                newName: "GiftProductId");

            migrationBuilder.RenameColumn(
                name: "expirationdate",
                table: "Promotions",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "discriminator",
                table: "Promotions",
                newName: "Discriminator");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Promotions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Promotions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_promotions_shopid",
                table: "Promotions",
                newName: "IX_Promotions_ShopId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "shopid",
                table: "Products",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "rackid",
                table: "Products",
                newName: "RackId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isinstock",
                table: "Products",
                newName: "IsInStock");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_products_shopid",
                table: "Products",
                newName: "IX_Products_ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_products_rackid",
                table: "Products",
                newName: "IX_Products_RackId");

            migrationBuilder.RenameColumn(
                name: "promotionsid",
                table: "ProductPromotion",
                newName: "PromotionsId");

            migrationBuilder.RenameColumn(
                name: "productsid",
                table: "ProductPromotion",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_productpromotion_promotionsid",
                table: "ProductPromotion",
                newName: "IX_ProductPromotion_PromotionsId");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Devices",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "rackid",
                table: "Devices",
                newName: "RackId");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Devices",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Devices",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_devices_rackid",
                table: "Devices",
                newName: "IX_Devices_RackId");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Companies",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "Companies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Companies",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "contactphone",
                table: "Companies",
                newName: "ContactPhone");

            migrationBuilder.RenameColumn(
                name: "contactemail",
                table: "Companies",
                newName: "ContactEmail");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "twofactorenabled",
                table: "AspNetUsers",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "shopid",
                table: "AspNetUsers",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "securitystamp",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phonenumberconfirmed",
                table: "AspNetUsers",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "AspNetUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalizedusername",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalizedemail",
                table: "AspNetUsers",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockoutend",
                table: "AspNetUsers",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockoutenabled",
                table: "AspNetUsers",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "emailconfirmed",
                table: "AspNetUsers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "AspNetUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "accessfailedcount",
                table: "AspNetUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_shopid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ShopId");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_roleid",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "providerdisplayname",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "providerkey",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "loginprovider",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_userid",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_userid",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "normalizedname",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "concurrencystamp",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claimvalue",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claimtype",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_roleid",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shops",
                table: "Shops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Racks",
                table: "Racks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPromotion",
                table: "ProductPromotion",
                columns: new[] { "ProductsId", "PromotionsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "676e80d4-1979-4a52-b224-3fdb92e6b8f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e074ac47-b1b6-4f1a-931a-89b23771e465");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "da111b47-14c0-4f41-9505-830f39384ec0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ef185ba-b632-4ea3-892d-8041308c8ad9", "AQAAAAEAACcQAAAAEE6WZuxUmyCU5SCAdbw2MKn6RrxcfkIrZ+T8wkuCalCShd3TEhHD8QL/Xuzc71hWCQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shops_ShopId",
                table: "AspNetUsers",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Racks_RackId",
                table: "Devices",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromotion_Products_ProductsId",
                table: "ProductPromotion",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromotion_Promotions_PromotionsId",
                table: "ProductPromotion",
                column: "PromotionsId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Racks_RackId",
                table: "Products",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Shops_ShopId",
                table: "Promotions",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Racks_AspNetUsers_UserId",
                table: "Racks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Racks_Shops_ShopId",
                table: "Racks",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId",
                table: "Reactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Products_ProductId",
                table: "Reactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Devices_DeviceId",
                table: "Records",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Racks_RackId",
                table: "Records",
                column: "RackId",
                principalTable: "Racks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
