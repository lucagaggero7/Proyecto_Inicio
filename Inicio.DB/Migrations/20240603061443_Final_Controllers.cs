using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inicio.DB.Migrations
{
    /// <inheritdoc />
    public partial class Final_Controllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profesiones_PersonaId",
                table: "Profesiones");

            migrationBuilder.CreateIndex(
                name: "Profesion_UQ",
                table: "Profesiones",
                columns: new[] { "PersonaId", "TituloId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Profesion_UQ",
                table: "Profesiones");

            migrationBuilder.CreateIndex(
                name: "IX_Profesiones_PersonaId",
                table: "Profesiones",
                column: "PersonaId");
        }
    }
}
