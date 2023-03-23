using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imobiliaria.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "IMOVEIS",
                columns: table => new
                {
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoImovelVenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeDoImovelCompra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorPedido = table.Column<double>(type: "float", nullable: false),
                    ValorDisponivel = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMOVEIS", x => x.ImovelId);
                    table.ForeignKey(
                        name: "FK_IMOVEIS_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMOVEIS_ClienteId",
                table: "IMOVEIS",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMOVEIS");

            migrationBuilder.DropTable(
                name: "CLIENTES");
        }
    }
}
