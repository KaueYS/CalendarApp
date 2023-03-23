using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations;

public partial class CarrinhoCompraItem : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CarrinhoCompraItens",
            columns: table => new
            {
                CarrinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LancheCCILancheId = table.Column<int>(type: "int", nullable: false),
                Quantidade = table.Column<int>(type: "int", nullable: false),
                CarrinhoCompraId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CarrinhoCompraItens", x => x.CarrinhoCompraItemId);
                table.ForeignKey(
                    name: "FK_CarrinhoCompraItens_Lanches_LancheCCILancheId",
                    column: x => x.LancheCCILancheId,
                    principalTable: "Lanches",
                    principalColumn: "LancheId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CarrinhoCompraItens_LancheCCILancheId",
            table: "CarrinhoCompraItens",
            column: "LancheCCILancheId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CarrinhoCompraItens");
    }
}
