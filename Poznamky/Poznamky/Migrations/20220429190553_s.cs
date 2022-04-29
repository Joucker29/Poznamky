using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poznamky.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JeDulezita",
                table: "Poznamky",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JeDulezita",
                table: "Poznamky");
        }
    }
}
