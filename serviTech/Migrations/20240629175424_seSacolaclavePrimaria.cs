using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class seSacolaclavePrimaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "Cliente_PersonasIdPersona",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonasIdPersona",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Cliente_PersonasIdPersona",
                table: "Personas",
                column: "Cliente_PersonasIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PersonasIdPersona",
                table: "Personas",
                column: "PersonasIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_Cliente_PersonasIdPersona",
                table: "Personas",
                column: "Cliente_PersonasIdPersona",
                principalTable: "Personas",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_PersonasIdPersona",
                table: "Personas",
                column: "PersonasIdPersona",
                principalTable: "Personas",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_Cliente_PersonasIdPersona",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_PersonasIdPersona",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Cliente_PersonasIdPersona",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PersonasIdPersona",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Cliente_PersonasIdPersona",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonasIdPersona",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonasIdPersona = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_PersonasIdPersona",
                        column: x => x.PersonasIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonasIdPersona = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Personas_PersonasIdPersona",
                        column: x => x.PersonasIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PersonasIdPersona",
                table: "Clientes",
                column: "PersonasIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PersonasIdPersona",
                table: "Empleados",
                column: "PersonasIdPersona");
        }
    }
}
