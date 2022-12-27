using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzDolabiVI.Data.Migrations
{
    public partial class adDegisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cinsiyet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ozluSoz",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sosyalMedya",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tarif",
                columns: table => new
                {
                    tarifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarifAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifOnay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifMalzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifNasilYapilir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifTarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    goruntulenme = table.Column<int>(type: "int", nullable: false),
                    tarifGirisYazisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kacKalori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    besinDegeriLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kacKisilik = table.Column<int>(type: "int", nullable: false),
                    hazirlanmaSuresi = table.Column<int>(type: "int", nullable: false),
                    pisirmeSuresi = table.Column<int>(type: "int", nullable: false),
                    kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ozluSoz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sosyalMedya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarif", x => x.tarifID);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    yorumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorumOnay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorumTarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorumIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorumAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorumOzluSoz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorumCinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorumSosyal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.yorumID);
                    table.ForeignKey(
                        name: "FK_Yorum_Tarif_tarifID",
                        column: x => x.tarifID,
                        principalTable: "Tarif",
                        principalColumn: "tarifID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_tarifID",
                table: "Yorum",
                column: "tarifID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.DropTable(
                name: "Tarif");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cinsiyet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ozluSoz",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "sosyalMedya",
                table: "AspNetUsers");
        }
    }
}
