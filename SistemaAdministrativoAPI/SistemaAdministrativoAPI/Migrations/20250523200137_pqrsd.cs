using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAdministrativoAPI.Migrations
{
    /// <inheritdoc />
    public partial class pqrsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pqrsds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Radicado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaRecibido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remitente = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Folios = table.Column<int>(type: "int", nullable: false),
                    Razon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RecibidoPor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaEntregaResponsable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiasFaltantes = table.Column<int>(type: "int", nullable: true),
                    Cumplimiento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pqrsds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsdId = table.Column<long>(type: "bigint", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivos_Pqrsds_PqrsdId",
                        column: x => x.PqrsdId,
                        principalTable: "Pqrsds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_PqrsdId",
                table: "Archivos",
                column: "PqrsdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "Pqrsds");
        }
    }
}
