using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramiaMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazevProduktu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PopisProduktu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SkladovaZasoba = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zakaznici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zakaznici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objednavky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumObjednavky = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZakaznikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objednavky", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objednavky_Zakaznici_ZakaznikId",
                        column: x => x.ZakaznikId,
                        principalTable: "Zakaznici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjednavkaPolozky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    ObjednavkaId = table.Column<int>(type: "int", nullable: false),
                    Mnozstvi = table.Column<int>(type: "int", nullable: false),
                    CenaZaJednotku = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjednavkaPolozky", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjednavkaPolozky_Objednavky_ObjednavkaId",
                        column: x => x.ObjednavkaId,
                        principalTable: "Objednavky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjednavkaPolozky_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjednavkaPolozky_ObjednavkaId",
                table: "ObjednavkaPolozky",
                column: "ObjednavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjednavkaPolozky_ProduktId",
                table: "ObjednavkaPolozky",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Objednavky_ZakaznikId",
                table: "Objednavky",
                column: "ZakaznikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjednavkaPolozky");

            migrationBuilder.DropTable(
                name: "Objednavky");

            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Zakaznici");
        }
    }
}
