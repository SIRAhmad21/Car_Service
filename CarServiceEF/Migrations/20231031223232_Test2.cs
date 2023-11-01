using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceEF.Migrations
{
    /// <inheritdoc />
    public partial class Test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationData",
                table: "Prodecet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Prodecet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Prodecet",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationData",
                table: "Prodecet");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Prodecet");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Prodecet");
        }
    }
}
