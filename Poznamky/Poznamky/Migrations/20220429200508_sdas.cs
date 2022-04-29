using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poznamky.Migrations
{
    public partial class sdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Poznamky",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Poznamky");
        }
    }
}
