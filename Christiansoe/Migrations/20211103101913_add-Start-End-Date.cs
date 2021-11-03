using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class addStartEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dezzznutzzz",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Field");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Field",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Field",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Field");

            migrationBuilder.AddColumn<string>(
                name: "Dezzznutzzz",
                table: "Field",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Field",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
