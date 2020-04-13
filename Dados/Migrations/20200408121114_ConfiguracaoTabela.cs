using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class ConfiguracaoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONFIGURACOES",
                columns: table => new
                {
                    CD_CONFIGURACAO = table.Column<string>(nullable: false),
                    VL_CONFIGURACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONFIGURACOES", x => x.CD_CONFIGURACAO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONFIGURACOES");
        }
    }
}
