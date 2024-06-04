using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inicio.DB.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TDocumentoId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TDocumentoId",
                table: "Personas");
        }
    }
}
