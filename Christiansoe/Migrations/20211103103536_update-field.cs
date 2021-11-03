using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Christiansoe.Migrations
{
    public partial class updatefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Field");

            migrationBuilder.AddColumn<int>(
                name: "EndMonth",
                table: "Field",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartMonth",
                table: "Field",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "StartMonth",
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
    }
}
