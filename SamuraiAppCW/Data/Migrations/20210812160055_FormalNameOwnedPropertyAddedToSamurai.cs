using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiAppCW.Data.Migrations
{
    public partial class FormalNameOwnedPropertyAddedToSamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Samurais");
        }
    }
}
