using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class Icollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinciaID",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaID",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_LocalidadID",
                table: "Empleados",
                column: "LocalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ProvinciaID",
                table: "Empleados",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes",
                column: "LocalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ProvinciaID",
                table: "Clientes",
                column: "ProvinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Localidades_LocalidadID",
                table: "Clientes",
                column: "LocalidadID",
                principalTable: "Localidades",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Provincias_ProvinciaID",
                table: "Clientes",
                column: "ProvinciaID",
                principalTable: "Provincias",
                principalColumn: "ProvinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Localidades_LocalidadID",
                table: "Empleados",
                column: "LocalidadID",
                principalTable: "Localidades",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Provincias_ProvinciaID",
                table: "Empleados",
                column: "ProvinciaID",
                principalTable: "Provincias",
                principalColumn: "ProvinciaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Localidades_LocalidadID",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Provincias_ProvinciaID",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Localidades_LocalidadID",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Provincias_ProvinciaID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_LocalidadID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_ProvinciaID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_LocalidadID",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ProvinciaID",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ProvinciaID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "ProvinciaID",
                table: "Clientes");
        }
    }
}
