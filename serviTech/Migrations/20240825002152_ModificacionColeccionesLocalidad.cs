using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionColeccionesLocalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes",
                column: "LocalidadID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes",
                column: "LocalidadID",
                unique: true);
        }
    }
}
