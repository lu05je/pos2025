using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _250217_Kundenliste.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefonnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Geburtsdatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Beschreibung = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Preis = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lagerbestand = table.Column<int>(type: "INTEGER", nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KundeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artikel_Kunden_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunden",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_KundeId",
                table: "Artikel",
                column: "KundeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Kunden");
        }
    }
}
