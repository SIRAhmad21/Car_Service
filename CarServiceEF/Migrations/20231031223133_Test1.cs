using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceEF.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prodecet",
                columns: table => new
                {
                    ProdectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodecet", x => x.ProdectId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodecet");
        }
    }
}
