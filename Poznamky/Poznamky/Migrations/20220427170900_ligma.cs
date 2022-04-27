using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poznamky.Migrations
{
    public partial class ligma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Poznamkyy",
                table: "Poznamkyy");

            migrationBuilder.RenameTable(
                name: "Poznamkyy",
                newName: "Poznamky");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Users",
                newName: "Jmeno");

            migrationBuilder.RenameColumn(
                name: "Heslo",
                table: "Users",
                newName: "Heslo_hashed");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poznamky",
                table: "Poznamky",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Poznamky",
                table: "Poznamky");

            migrationBuilder.RenameTable(
                name: "Poznamky",
                newName: "Poznamkyy");

            migrationBuilder.RenameColumn(
                name: "Jmeno",
                table: "Users",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Heslo_hashed",
                table: "Users",
                newName: "Heslo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poznamkyy",
                table: "Poznamkyy",
                column: "Id");
        }
    }
}
