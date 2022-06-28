using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brazilla.EntityFramework.Migrations
{
    public partial class BlendAndTypesDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blends_Blend types_TypeFK",
                table: "Blends");

            migrationBuilder.AddForeignKey(
                name: "FK_Blends_Blend types_TypeFK",
                table: "Blends",
                column: "TypeFK",
                principalTable: "Blend types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blends_Blend types_TypeFK",
                table: "Blends");

            migrationBuilder.AddForeignKey(
                name: "FK_Blends_Blend types_TypeFK",
                table: "Blends",
                column: "TypeFK",
                principalTable: "Blend types",
                principalColumn: "Id");
        }
    }
}
