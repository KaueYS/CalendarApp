using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCImobiliaria.Migrations
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IMOVEIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMOVEIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTEIMOVEIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTEIMOVEIS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CLIENTEIMOVEIS_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLIENTEIMOVEIS_IMOVEIS_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "IMOVEIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTEINTERESSEIMOVEIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false),
                    ClienteOferta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImovelDiferenca = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTEINTERESSEIMOVEIS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CLIENTEINTERESSEIMOVEIS_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLIENTEINTERESSEIMOVEIS_IMOVEIS_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "IMOVEIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IMOVELDETALHES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMOVELDETALHES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IMOVELDETALHES_IMOVEIS_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "IMOVEIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTEIMOVEIS_ClienteId",
                table: "CLIENTEIMOVEIS",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTEIMOVEIS_ImovelId",
                table: "CLIENTEIMOVEIS",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTEINTERESSEIMOVEIS_ClienteId",
                table: "CLIENTEINTERESSEIMOVEIS",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTEINTERESSEIMOVEIS_ImovelId",
                table: "CLIENTEINTERESSEIMOVEIS",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_IMOVELDETALHES_ImovelId",
                table: "IMOVELDETALHES",
                column: "ImovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTEIMOVEIS");

            migrationBuilder.DropTable(
                name: "CLIENTEINTERESSEIMOVEIS");

            migrationBuilder.DropTable(
                name: "IMOVELDETALHES");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "IMOVEIS");
        }
    }
}
