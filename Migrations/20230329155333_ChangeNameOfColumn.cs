using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApp2023.Migrations
{
    public partial class ChangeNameOfColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Clouds",
                table: "DataPoint",
                newName: "Cloud");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cloud",
                table: "DataPoint",
                newName: "Clouds");
        }
    }
}
