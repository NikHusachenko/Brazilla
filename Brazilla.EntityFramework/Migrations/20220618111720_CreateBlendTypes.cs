using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brazilla.EntityFramework.Migrations
{
    public partial class CreateBlendTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Types",
                table: "Blends");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(31)",
                maxLength: 31,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Blend types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlendFK = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blend types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blend types_Blends_BlendFK",
                        column: x => x.BlendFK,
                        principalTable: "Blends",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blend types_BlendFK",
                table: "Blend types",
                column: "BlendFK",
                unique: true,
                filter: "[BlendFK] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blend types");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(31)",
                oldMaxLength: 31);

            migrationBuilder.AddColumn<int>(
                name: "Types",
                table: "Blends",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
