using Microsoft.EntityFrameworkCore.Migrations;

namespace GoDAPI.Migrations
{
    public partial class addEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Winner",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Winner",
                table: "Games",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
