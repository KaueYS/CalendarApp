using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobiliariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Troca",
                table: "IMOVEIS");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "IMOVEIS",
                newName: "ValorPedido");

            migrationBuilder.AddColumn<double>(
                name: "ValorDisponivelParaVolta",
                table: "IMOVEIS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorDisponivelParaVolta",
                table: "IMOVEIS");

            migrationBuilder.RenameColumn(
                name: "ValorPedido",
                table: "IMOVEIS",
                newName: "Valor");

            migrationBuilder.AddColumn<bool>(
                name: "Troca",
                table: "IMOVEIS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
