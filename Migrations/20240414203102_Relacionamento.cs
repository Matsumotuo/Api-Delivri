using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace delivri.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LojasId",
                table: "Cardapio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_LojasId",
                table: "Cardapio",
                column: "LojasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cardapio_Lojas_LojasId",
                table: "Cardapio",
                column: "LojasId",
                principalTable: "Lojas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cardapio_Lojas_LojasId",
                table: "Cardapio");

            migrationBuilder.DropIndex(
                name: "IX_Cardapio_LojasId",
                table: "Cardapio");

            migrationBuilder.DropColumn(
                name: "LojasId",
                table: "Cardapio");
        }
    }
}
