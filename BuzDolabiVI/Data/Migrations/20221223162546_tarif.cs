using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzDolabiVI.Data.Migrations
{
    public partial class tarif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Tarif",
                columns: table => new
                {
                    tarifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Tarif", x => x.tarifID);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    yorumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    kullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategoriID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    onay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifID = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    icerik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.yorumID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarif");

            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
