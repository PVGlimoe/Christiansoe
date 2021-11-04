using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class initualize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoundUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartMonth = table.Column<int>(type: "int", nullable: false),
                    EndMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BingoBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BingoBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BingoBoard_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    HikingTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BingoBoardId = table.Column<int>(type: "int", nullable: true),
                    MapId = table.Column<int>(type: "int", nullable: true),
                    ThemeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_BingoBoard_BingoBoardId",
                        column: x => x.BingoBoardId,
                        principalTable: "BingoBoard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Route_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Route_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BingoBoard_MapId",
                table: "BingoBoard",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_BingoBoardField_FieldsId",
                table: "BingoBoardField",
                column: "FieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_BingoBoardId",
                table: "Route",
                column: "BingoBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_MapId",
                table: "Route",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ThemeId",
                table: "Route",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BingoBoardField");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "BingoBoard");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropTable(
                name: "Map");
        }
    }
}
