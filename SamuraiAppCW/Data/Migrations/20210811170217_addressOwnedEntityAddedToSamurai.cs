using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiAppCW.Data.Migrations
{
    public partial class addressOwnedEntityAddedToSamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Samurais");
        }
    }
}
