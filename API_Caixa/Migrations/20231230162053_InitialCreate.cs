using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Caixa_Relatorio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Fluxo_Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovimento = table.Column<string>(maxLength: 1, nullable: true),
                    ValorMovimentacao = table.Column<decimal>(nullable: false),
                    DataMovimentacao = table.Column<DateTime>(nullable: false),
                    DescricaoMovimentacao = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Fluxo_Caixa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Fluxo_Caixa");
        }
    }
}
