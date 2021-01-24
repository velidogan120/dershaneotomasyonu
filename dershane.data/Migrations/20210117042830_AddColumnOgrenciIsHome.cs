using Microsoft.EntityFrameworkCore.Migrations;

namespace dershane.data.Migrations
{
    public partial class AddColumnOgrenciIsHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Ogrenciler",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Ogrenciler");
        }
    }
}
