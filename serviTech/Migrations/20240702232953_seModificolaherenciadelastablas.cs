using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serviTech.Migrations
{
    /// <inheritdoc />
    public partial class seModificolaherenciadelastablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Provincias_ProvinciasIdProvincia",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_Cliente_PersonaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_PersonaId",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Cliente_PersonaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PersonaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Cliente_PersonaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "IdProvincia",
                table: "Provincias",
                newName: "ProvinciaID");

            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Personas",
                newName: "PersonaID");

            migrationBuilder.RenameColumn(
                name: "IdProvincia",
                table: "Personas",
                newName: "ProvinciaID");

            migrationBuilder.RenameColumn(
                name: "IdLocalidad",
                table: "Personas",
                newName: "LocalidadID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Personas",
                newName: "CP");

            migrationBuilder.RenameColumn(
                name: "ProvinciasIdProvincia",
                table: "Localidades",
                newName: "ProvinciaID");

            migrationBuilder.RenameColumn(
                name: "IdLocalidad",
                table: "Localidades",
                newName: "LocalidadID");

            migrationBuilder.RenameIndex(
                name: "IX_Localidades_ProvinciasIdProvincia",
                table: "Localidades",
                newName: "IX_Localidades_ProvinciaID");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CP",
                table: "Personas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "PersonaID");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleados_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PersonaID",
                table: "Clientes",
                column: "PersonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PersonaID",
                table: "Empleados",
                column: "PersonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaID",
                table: "Localidades",
                column: "ProvinciaID",
                principalTable: "Provincias",
                principalColumn: "ProvinciaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaID",
                table: "Localidades");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "ProvinciaID",
                table: "Provincias",
                newName: "IdProvincia");

            migrationBuilder.RenameColumn(
                name: "PersonaID",
                table: "Personas",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "ProvinciaID",
                table: "Personas",
                newName: "IdProvincia");

            migrationBuilder.RenameColumn(
                name: "LocalidadID",
                table: "Personas",
                newName: "IdLocalidad");

            migrationBuilder.RenameColumn(
                name: "CP",
                table: "Personas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProvinciaID",
                table: "Localidades",
                newName: "ProvinciasIdProvincia");

            migrationBuilder.RenameColumn(
                name: "LocalidadID",
                table: "Localidades",
                newName: "IdLocalidad");

            migrationBuilder.RenameIndex(
                name: "IX_Localidades_ProvinciaID",
                table: "Localidades",
                newName: "IX_Localidades_ProvinciasIdProvincia");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Personas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Cliente_PersonaId",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Cliente_PersonaId",
                table: "Personas",
                column: "Cliente_PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PersonaId",
                table: "Personas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Provincias_ProvinciasIdProvincia",
                table: "Localidades",
                column: "ProvinciasIdProvincia",
                principalTable: "Provincias",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_Cliente_PersonaId",
                table: "Personas",
                column: "Cliente_PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_PersonaId",
                table: "Personas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
