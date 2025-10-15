using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeMapQROOBackend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albergues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Latidud = table.Column<double>(type: "REAL", nullable: false),
                    Longitud = table.Column<double>(type: "REAL", nullable: false),
                    Capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Ocupantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Disponible = table.Column<bool>(type: "INTEGER", nullable: false),
                    Eliminado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albergues", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albergues");
        }
    }
}
