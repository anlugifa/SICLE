using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class TabelaPerfilVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ST_PROVISION_APPROVER",
                table: "TB_PERFIS_VENDA",
                newName: "ST_CONTRACT_PRICE_APPROVER");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME",
                table: "TB_PERFIS_VENDA",
                type: "decimal(38, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ST_CONTRACT_PRICE_APPROVER",
                table: "TB_PERFIS_VENDA",
                newName: "ST_PROVISION_APPROVER");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38, 9)");
        }
    }
}
