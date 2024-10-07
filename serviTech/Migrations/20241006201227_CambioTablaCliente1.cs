using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class CambioTablaCliente1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
