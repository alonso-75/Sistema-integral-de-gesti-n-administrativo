using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAdministrativoAPI.Migrations
{
    /// <inheritdoc />
    public partial class version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_ciudadanos_CiudadanoId",
                table: "Atenciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ciudadanos",
                table: "ciudadanos");

            migrationBuilder.RenameTable(
                name: "ciudadanos",
                newName: "Ciudadanos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudadanos",
                table: "Ciudadanos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_Ciudadanos_CiudadanoId",
                table: "Atenciones",
                column: "CiudadanoId",
                principalTable: "Ciudadanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atenciones_Ciudadanos_CiudadanoId",
                table: "Atenciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudadanos",
                table: "Ciudadanos");

            migrationBuilder.RenameTable(
                name: "Ciudadanos",
                newName: "ciudadanos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ciudadanos",
                table: "ciudadanos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atenciones_ciudadanos_CiudadanoId",
                table: "Atenciones",
                column: "CiudadanoId",
                principalTable: "ciudadanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
