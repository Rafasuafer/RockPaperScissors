using Microsoft.EntityFrameworkCore.Migrations;

namespace GoDAPI.Migrations
{
    public partial class movesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mOne",
                table: "Battles",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mTwo",
                table: "Battles",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mOne",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "mTwo",
                table: "Battles");
        }
    }
}
