using Microsoft.EntityFrameworkCore.Migrations;

namespace GadgetsShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gadget",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    shortDescription = table.Column<string>(nullable: true),
                    longDescription = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    isFavourite = table.Column<bool>(nullable: false),
                    available = table.Column<bool>(nullable: false),
                    categoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gadget", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gadget_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gadget_categoryID",
                table: "Gadget",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gadget");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
