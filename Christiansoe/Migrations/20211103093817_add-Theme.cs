using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class addTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Route_ThemeId",
                table: "Route",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Theme_ThemeId",
                table: "Route",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Theme_ThemeId",
                table: "Route");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Route_ThemeId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
