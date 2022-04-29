using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poznamky.Migrations
{
    public partial class nwm_men : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prezdivka",
                table: "Poznamky",
                newName: "Nadpis");

            migrationBuilder.AddColumn<DateTime>(
                name: "CasPridani",
                table: "Poznamky",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CasPridani",
                table: "Poznamky");

            migrationBuilder.RenameColumn(
                name: "Nadpis",
                table: "Poznamky",
                newName: "Prezdivka");
        }
    }
}
