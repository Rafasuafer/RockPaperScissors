using Microsoft.EntityFrameworkCore.Migrations;

namespace GoDAPI.Migrations
{
    public partial class moves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoveOne",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "MoveTwo",
                table: "Battles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoveOne",
                table: "Battles",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MoveTwo",
                table: "Battles",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
