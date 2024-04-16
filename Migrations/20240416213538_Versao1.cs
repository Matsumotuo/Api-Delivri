using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace delivri.Migrations
{
    /// <inheritdoc />
    public partial class Versao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cardapio_CardapioId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_CardapioId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CardapioId",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUser",
                table: "Usuario",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateTable(
                name: "LojasCardapio",
                columns: table => new
                {
                    CardapioId = table.Column<int>(type: "int", nullable: false),
                    LojasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LojasCardapio", x => new { x.CardapioId, x.LojasId });
                    table.ForeignKey(
                        name: "FK_LojasCardapio_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LojasCardapio_Lojas_LojasId",
                        column: x => x.LojasId,
                        principalTable: "Lojas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LojasCardapio_LojasId",
                table: "LojasCardapio",
                column: "LojasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LojasCardapio");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUser",
                table: "Usuario",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardapioId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CardapioId",
                table: "Pedido",
                column: "CardapioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cardapio_CardapioId",
                table: "Pedido",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id");
        }
    }
}
