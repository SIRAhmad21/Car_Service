using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceEF.Migrations
{
    /// <inheritdoc />
    public partial class Car1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Prodecet");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Prodecet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Prodecet");

            migrationBuilder.AddColumn<string>(
                name: "DiscountPrice",
                table: "Prodecet",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
