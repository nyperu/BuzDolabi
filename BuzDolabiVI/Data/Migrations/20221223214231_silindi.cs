using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzDolabiVI.Data.Migrations
{
    public partial class silindi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarif");

            migrationBuilder.CreateTable(
                name: "Tarifler1",
                columns: table => new
                {
                    tarifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarifAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifMalzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifNasilYapilir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    goruntulenme = table.Column<int>(type: "int", nullable: false),
                    tarifGirisYazisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kacKalori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    besinDegeriLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kacKisilik = table.Column<int>(type: "int", nullable: false),
                    hazirlanmaSuresi = table.Column<int>(type: "int", nullable: false),
                    pisirmeSuresi = table.Column<int>(type: "int", nullable: false),
                    yazarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazarOzluSoz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazarCinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazarSosyal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifler1", x => x.tarifID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifler1");

            migrationBuilder.CreateTable(
                name: "Tarif",
                columns: table => new
                {
                    tarifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    besinDegeriLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    goruntulenme = table.Column<int>(type: "int", nullable: false),
                    hazirlanmaSuresi = table.Column<int>(type: "int", nullable: false),
                    kacKalori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kacKisilik = table.Column<int>(type: "int", nullable: false),
                    pisirmeSuresi = table.Column<int>(type: "int", nullable: false),
                    tarifAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifGirisYazisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifMalzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifNasilYapilir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    yazarAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazarCinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazarOzluSoz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazarSosyal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarif", x => x.tarifID);
                });
        }
    }
}
