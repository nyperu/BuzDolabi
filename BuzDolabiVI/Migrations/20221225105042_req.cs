using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuzDolabiVI.Migrations
{
    public partial class req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarif_AspNetUsers_tarifKullaniciId",
                table: "Tarif");

            migrationBuilder.AlterColumn<string>(
                name: "tarifKullaniciId",
                table: "Tarif",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarif_AspNetUsers_tarifKullaniciId",
                table: "Tarif",
                column: "tarifKullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarif_AspNetUsers_tarifKullaniciId",
                table: "Tarif");

            migrationBuilder.AlterColumn<string>(
                name: "tarifKullaniciId",
                table: "Tarif",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarif_AspNetUsers_tarifKullaniciId",
                table: "Tarif",
                column: "tarifKullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
