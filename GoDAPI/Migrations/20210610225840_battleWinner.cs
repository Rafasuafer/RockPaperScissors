using Microsoft.EntityFrameworkCore.Migrations;

namespace GoDAPI.Migrations
{
    public partial class battleWinner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "winner",
                table: "Battles",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "winner",
                table: "Battles");
        }
    }
}
