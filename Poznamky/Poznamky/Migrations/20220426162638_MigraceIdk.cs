using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poznamky.Migrations
{
    public partial class MigraceIdk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Poznamky",
                table: "Poznamky");

            migrationBuilder.RenameTable(
                name: "Poznamky",
                newName: "Poznamkyy");

            migrationBuilder.AddColumn<string>(
                name: "Heslo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poznamkyy",
                table: "Poznamkyy",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Poznamkyy",
                table: "Poznamkyy");

            migrationBuilder.DropColumn(
                name: "Heslo",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Poznamkyy",
                newName: "Poznamky");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poznamky",
                table: "Poznamky",
                column: "Id");
        }
    }
}
