using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobiliariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjustesModelImovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMOVEIS_CLIENTES_ClientesClienteId",
                table: "IMOVEIS");

            migrationBuilder.DropIndex(
                name: "IX_IMOVEIS_ClientesClienteId",
                table: "IMOVEIS");

            migrationBuilder.DropColumn(
                name: "ClientesClienteId",
                table: "IMOVEIS");

            migrationBuilder.RenameColumn(
                name: "QualImovel",
                table: "IMOVEIS",
                newName: "ImovelParaTroca");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "IMOVEIS",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_IMOVEIS_ClienteId",
                table: "IMOVEIS",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_IMOVEIS_CLIENTES_ClienteId",
                table: "IMOVEIS",
                column: "ClienteId",
                principalTable: "CLIENTES",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMOVEIS_CLIENTES_ClienteId",
                table: "IMOVEIS");

            migrationBuilder.DropIndex(
                name: "IX_IMOVEIS_ClienteId",
                table: "IMOVEIS");

            migrationBuilder.RenameColumn(
                name: "ImovelParaTroca",
                table: "IMOVEIS",
                newName: "QualImovel");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteId",
                table: "IMOVEIS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientesClienteId",
                table: "IMOVEIS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IMOVEIS_ClientesClienteId",
                table: "IMOVEIS",
                column: "ClientesClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_IMOVEIS_CLIENTES_ClientesClienteId",
                table: "IMOVEIS",
                column: "ClientesClienteId",
                principalTable: "CLIENTES",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
