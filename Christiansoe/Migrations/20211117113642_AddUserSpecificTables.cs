using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class AddUserSpecificTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBingoBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    BingoBoardId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBingoBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBingoBoard_BingoBoard_BingoBoardId",
                        column: x => x.BingoBoardId,
                        principalTable: "BingoBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMarked = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: true),
                    UserBingoBoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserField_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserField_UserBingoBoard_UserBingoBoardId",
                        column: x => x.UserBingoBoardId,
                        principalTable: "UserBingoBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBingoBoard_BingoBoardId",
                table: "UserBingoBoard",
                column: "BingoBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserField_FieldId",
                table: "UserField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserField_UserBingoBoardId",
                table: "UserField",
                column: "UserBingoBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserField");

            migrationBuilder.DropTable(
                name: "UserBingoBoard");
        }
    }
}
