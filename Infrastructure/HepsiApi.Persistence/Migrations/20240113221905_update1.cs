using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(4816), "Grocery & Electronics" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(4873), "Clothing & Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(4879), "Electronics" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 14, 1, 19, 5, 341, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 344, DateTimeKind.Local).AddTicks(4060), "Architecto sarmal eum nostrum salladı.", "Dignissimos." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 344, DateTimeKind.Local).AddTicks(4150), "Quia voluptate mutlu filmini quae.", "Sıla perferendis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 344, DateTimeKind.Local).AddTicks(4184), "Yazın architecto balıkhaneye türemiş beatae.", "Değirmeni." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 348, DateTimeKind.Local).AddTicks(578), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 0.88537647904997100m, 554.06m, "Handmade Concrete Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 14, 1, 19, 5, 348, DateTimeKind.Local).AddTicks(607), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 33.491019745137200m, 29.32m, "Ergonomic Granite Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9225), "Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9283), "Electronics, Automotive & Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9298), "Beauty, Health & Beauty" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1425), "Sevindi enim sunt sıradanlıktan consequuntur.", "Sandalye." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1496), "Eve dolor karşıdakine qui bundan.", "Ve mutlu." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1529), "Çorba ut aut minima exercitationem.", "Aut." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 17, DateTimeKind.Local).AddTicks(4535), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 25.490218742405200m, 48.35m, "Sleek Rubber Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 12, 18, 40, 54, 17, DateTimeKind.Local).AddTicks(4559), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 28.829056385503800m, 423.34m, "Generic Plastic Car" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsID",
                table: "CategoryProduct",
                column: "ProductsID");
        }
    }
}
