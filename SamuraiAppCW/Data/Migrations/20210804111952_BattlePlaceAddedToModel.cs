using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiAppCW.Data.Migrations
{
    public partial class BattlePlaceAddedToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BattlePlace",
                table: "Battles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BattlePlace",
                table: "Battles");
        }
    }
}
