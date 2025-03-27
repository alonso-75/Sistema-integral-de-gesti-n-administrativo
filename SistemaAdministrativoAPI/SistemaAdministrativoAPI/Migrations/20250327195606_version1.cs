using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAdministrativoAPI.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Ciudadanos_CiudadanoId",
                table: "Atenciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Ciudadanos_CiudadanoId",
                table: "Atenciones",
                column: "CiudadanoId",
                principalTable: "Ciudadanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Ciudadanos_CiudadanoId",
                table: "Atenciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Ciudadanos_CiudadanoId",
                table: "Atenciones",
                column: "CiudadanoId",
                principalTable: "Ciudadanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
