using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"), "Phone" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"), "Notebook" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Price", "ProductName", "Stock" },
                values: new object[] { new Guid("054ab3c6-5604-4428-9587-852f6d7c8da4"), new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"), "Gold", 20000m, "Apple", 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Price", "ProductName", "Stock" },
                values: new object[] { new Guid("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7"), new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"), "Silver", 10000m, "Samsung", 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Price", "ProductName", "Stock" },
                values: new object[] { new Guid("5f729da8-d97a-4eb7-bd38-9bbb6a593a9d"), new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"), "Black", 15000m, "Macbook", 30 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Price", "ProductName", "Stock" },
                values: new object[] { new Guid("ed44afb2-3a9f-40f6-a3ff-ef76a1232348"), new Guid("ca110d28-c66c-4eee-8e20-3576b9dd26d6"), "Black", 15000m, "Huawei", 30 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
