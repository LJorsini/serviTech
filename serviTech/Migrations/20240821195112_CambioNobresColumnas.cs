using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class CambioNobresColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Provincias",
                newName: "NombreProvincia");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Localidades",
                newName: "NombreLocalidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreProvincia",
                table: "Provincias",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreLocalidad",
                table: "Localidades",
                newName: "Nombre");
        }
    }
}
