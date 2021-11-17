using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class remove_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BingoBoardField");

            migrationBuilder.AddColumn<int>(
                name: "BingoBoardId",
                table: "Field",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Field_BingoBoardId",
                table: "Field",
                column: "BingoBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Field_BingoBoard_BingoBoardId",
                table: "Field",
                column: "BingoBoardId",
                principalTable: "BingoBoard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_BingoBoard_BingoBoardId",
                table: "Field");

            migrationBuilder.DropIndex(
                name: "IX_Field_BingoBoardId",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "BingoBoardId",
                table: "Field");

            migrationBuilder.CreateTable(
                name: "BingoBoardField",
                columns: table => new
                {
                    BingoBoardsId = table.Column<int>(type: "int", nullable: false),
                    FieldsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoBoardField", x => new { x.BingoBoardsId, x.FieldsId });
                    table.ForeignKey(
                        name: "FK_BingoBoardField_BingoBoard_BingoBoardsId",
                        column: x => x.BingoBoardsId,
                        principalTable: "BingoBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BingoBoardField_Field_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BingoBoardField_FieldsId",
                table: "BingoBoardField",
                column: "FieldsId");
        }
    }
}
