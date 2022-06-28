using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brazilla.EntityFramework.Migrations
{
    public partial class ChangeRelationshipBetweenTypeAndBlend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blend types_Blends_BlendFK",
                table: "Blend types");

            migrationBuilder.DropIndex(
                name: "IX_Blend types_BlendFK",
                table: "Blend types");

            migrationBuilder.DropColumn(
                name: "BlendFK",
                table: "Blend types");

            migrationBuilder.AddColumn<long>(
                name: "TypeFK",
                table: "Blends",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blends_TypeFK",
                table: "Blends",
                column: "TypeFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Blends_Blend types_TypeFK",
                table: "Blends",
                column: "TypeFK",
                principalTable: "Blend types",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blends_Blend types_TypeFK",
                table: "Blends");

            migrationBuilder.DropIndex(
                name: "IX_Blends_TypeFK",
                table: "Blends");

            migrationBuilder.DropColumn(
                name: "TypeFK",
                table: "Blends");

            migrationBuilder.AddColumn<long>(
                name: "BlendFK",
                table: "Blend types",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blend types_BlendFK",
                table: "Blend types",
                column: "BlendFK",
                unique: true,
                filter: "[BlendFK] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Blend types_Blends_BlendFK",
                table: "Blend types",
                column: "BlendFK",
                principalTable: "Blends",
                principalColumn: "Id");
        }
    }
}
