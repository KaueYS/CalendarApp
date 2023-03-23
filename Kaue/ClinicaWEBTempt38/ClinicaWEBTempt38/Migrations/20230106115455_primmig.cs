using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaWEBTempt38.Migrations
{
    /// <inheritdoc />
    public partial class primmig : Migration
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
                    Telefone = table.Column<string>(type: "nvarchar(20)", nullable: false)
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
                    ProcedimentoNome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProcedimentoPreco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCEDIMENTOS", x => x.ProcedimentoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "PROCEDIMENTOS");
        }
    }
}
