using Microsoft.EntityFrameworkCore.Migrations;

namespace dershane.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolumler",
                columns: table => new
                {
                    BolumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.BolumId);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Sınıf = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.OgrenciId);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciBolum",
                columns: table => new
                {
                    BolumId = table.Column<int>(type: "INTEGER", nullable: false),
                    OgrenciId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciBolum", x => new { x.BolumId, x.OgrenciId });
                    table.ForeignKey(
                        name: "FK_OgrenciBolum_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "BolumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciBolum_Ogrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenciler",
                        principalColumn: "OgrenciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciBolum_OgrenciId",
                table: "OgrenciBolum",
                column: "OgrenciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciBolum");

            migrationBuilder.DropTable(
                name: "Bolumler");

            migrationBuilder.DropTable(
                name: "Ogrenciler");
        }
    }
}
