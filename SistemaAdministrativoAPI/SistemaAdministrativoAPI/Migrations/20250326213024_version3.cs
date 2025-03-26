using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAdministrativoAPI.Migrations
{
    /// <inheritdoc />
    public partial class version3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ciudadanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PertenenciaEtnica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoPoblacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TelefonosContacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudadanos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescripcionEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEquipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiudadanoId = table.Column<int>(type: "int", nullable: false),
                    TipoAtencion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtendidoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DependenciaAtiende = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OficinaProgramaAtiende = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atenciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atenciones_ciudadanos_CiudadanoId",
                        column: x => x.CiudadanoId,
                        principalTable: "ciudadanos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosEquipos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<long>(type: "bigint", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrestadoA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactoPrestatario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EstadoPrestamo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosEquipos", x => x.Id);
                    table.CheckConstraint("CK_EstadoPrestamo", "EstadoPrestamo IN ('Pendiente', 'En curso', 'Devuelto', 'Retrasado')");
                    table.ForeignKey(
                        name: "FK_PrestamosEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_CiudadanoId",
                table: "Atenciones",
                column: "CiudadanoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosEquipos_EquipoId",
                table: "PrestamosEquipos",
                column: "EquipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "PrestamosEquipos");

            migrationBuilder.DropTable(
                name: "ciudadanos");

            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
