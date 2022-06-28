using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brazilla.EntityFramework.Migrations
{
    public partial class AddedBlendTypePercent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Arabica",
                table: "Blend types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Robusta",
                table: "Blend types",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arabica",
                table: "Blend types");

            migrationBuilder.DropColumn(
                name: "Robusta",
                table: "Blend types");
        }
    }
}
