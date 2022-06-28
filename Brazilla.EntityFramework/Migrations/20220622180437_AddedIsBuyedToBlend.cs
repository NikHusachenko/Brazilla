using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brazilla.EntityFramework.Migrations
{
    public partial class AddedIsBuyedToBlend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBuyed",
                table: "Blends",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBuyed",
                table: "Blends");
        }
    }
}
