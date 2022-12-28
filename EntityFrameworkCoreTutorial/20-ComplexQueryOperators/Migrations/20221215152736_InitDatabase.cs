using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _20_ComplexQueryOperators.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Photos_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Gender", "Name" },
                values: new object[] { 1, 1, "Sedat" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Gender", "Name" },
                values: new object[] { 2, 0, "Burcu" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Gender", "Name" },
                values: new object[] { 3, 0, "Canan" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Description", "PersonId" },
                values: new object[] { 1, "This is Sedat's order.", 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Description", "PersonId" },
                values: new object[] { 2, "This is Burcu's order.", 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Description", "PersonId" },
                values: new object[] { 3, "This is Canan's order.", 3 });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PersonId", "Url" },
                values: new object[] { 1, "https://fotofoto.com/1" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PersonId", "Url" },
                values: new object[] { 2, "https://fotofoto.com/2" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PersonId", "Url" },
                values: new object[] { 3, "https://fotofoto.com/3" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
