using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class TabelaPerfilAddColumCreditLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VL_MAX_CREDIT_LIMIT",
                table: "TB_PERFIS",
                type: "decimal(38,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VL_MAX_CREDIT_LIMIT",
                table: "TB_PERFIS");
        }
    }
}
