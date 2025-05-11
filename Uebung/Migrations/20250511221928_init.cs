using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uebung.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objekte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Beschreibung = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objekte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListenObjekte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ObjektId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenObjekte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenObjekte_Objekte_ObjektId",
                        column: x => x.ObjektId,
                        principalTable: "Objekte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListenObjekte_ObjektId",
                table: "ListenObjekte",
                column: "ObjektId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListenObjekte");

            migrationBuilder.DropTable(
                name: "Objekte");
        }
    }
}
