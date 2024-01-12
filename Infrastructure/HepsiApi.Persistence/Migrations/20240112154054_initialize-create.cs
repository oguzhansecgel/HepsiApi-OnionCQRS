using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HepsiApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initializecreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9225), false, "Sports" },
                    { 2, new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9283), false, "Electronics, Automotive & Beauty" },
                    { 3, new DateTime(2024, 1, 12, 18, 40, 54, 11, DateTimeKind.Local).AddTicks(9298), true, "Beauty, Health & Beauty" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "Name", "ParentID", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2761), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2762), false, "Moda", 0, 2 },
                    { 3, new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2764), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2024, 1, 12, 18, 40, 54, 12, DateTimeKind.Local).AddTicks(2765), false, "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1425), "Sevindi enim sunt sıradanlıktan consequuntur.", false, "Sandalye." },
                    { 2, 3, new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1496), "Eve dolor karşıdakine qui bundan.", true, "Ve mutlu." },
                    { 3, 4, new DateTime(2024, 1, 12, 18, 40, 54, 15, DateTimeKind.Local).AddTicks(1529), "Çorba ut aut minima exercitationem.", false, "Aut." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 12, 18, 40, 54, 17, DateTimeKind.Local).AddTicks(4535), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 25.490218742405200m, false, 48.35m, "Sleek Rubber Tuna" },
                    { 2, 3, new DateTime(2024, 1, 12, 18, 40, 54, 17, DateTimeKind.Local).AddTicks(4559), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 28.829056385503800m, false, 423.34m, "Generic Plastic Car" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsID",
                table: "CategoryProduct",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryID",
                table: "Details",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
