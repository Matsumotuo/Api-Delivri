using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace delivri.Migrations
{
    /// <inheritdoc />
    public partial class VersaoTres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LojaCardapio",
                table: "LojaCardapio");

            migrationBuilder.DropIndex(
                name: "IX_LojaCardapio_LojaId",
                table: "LojaCardapio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LojaCardapio",
                table: "LojaCardapio",
                columns: new[] { "LojaId", "CardapioId" });

            migrationBuilder.CreateIndex(
                name: "IX_LojaCardapio_CardapioId",
                table: "LojaCardapio",
                column: "CardapioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LojaCardapio",
                table: "LojaCardapio");

            migrationBuilder.DropIndex(
                name: "IX_LojaCardapio_CardapioId",
                table: "LojaCardapio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LojaCardapio",
                table: "LojaCardapio",
                columns: new[] { "CardapioId", "LojaId" });

            migrationBuilder.CreateIndex(
                name: "IX_LojaCardapio_LojaId",
                table: "LojaCardapio",
                column: "LojaId");
        }
    }
}
