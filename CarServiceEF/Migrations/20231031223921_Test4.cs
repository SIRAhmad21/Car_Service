using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceEF.Migrations
{
    /// <inheritdoc />
    public partial class Test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdectType",
                table: "Prodecet",
                newName: "Size");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Prodecet",
                newName: "ProdectType");
        }
    }
}
