using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionCampoDni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "Dni",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes",
                column: "LocalidadID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "Dni",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes",
                column: "LocalidadID");
        }
    }
}
