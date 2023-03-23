using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaWebEF.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "PROCEDIMENTOS",
                columns: table => new
                {
                    ProcedimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCEDIMENTOS", x => x.ProcedimentoId);
                    table.ForeignKey(
                        name: "FK_PROCEDIMENTOS_PACIENTES_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTES",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROCEDIMENTOS_PacienteId",
                table: "PROCEDIMENTOS",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROCEDIMENTOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");
        }
    }
}
