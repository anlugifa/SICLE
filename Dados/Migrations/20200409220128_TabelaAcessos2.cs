using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class TabelaAcessos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractPriceApprover",
                table: "TB_PERFIS_VENDA");

            migrationBuilder.AlterColumn<float>(
                name: "VL_VOLUME_SUBPRODUTO",
                table: "TB_PERFIS_VENDA",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "VL_VOLUME_DERIVATIVO",
                table: "TB_PERFIS_VENDA",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_ORDEM_CONTRATO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(9, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_CONTRATO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(9, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_COMPLEMENTO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(9, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME",
                table: "TB_PERFIS_VENDA",
                type: "decimal(9, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38, 9)");

            migrationBuilder.AlterColumn<float>(
                name: "VL_VALOR_COMPLEMENTO_PRECO",
                table: "TB_PERFIS_VENDA",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_PRAZO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(38, 0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_MAX_PERIODO_CONTRATO_ME",
                table: "TB_PERFIS_VENDA",
                type: "decimal(10, 0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_MAX_PERIODO_CONTRATO_MI",
                table: "TB_PERFIS_VENDA",
                type: "decimal(10, 0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "ST_PROVISION_APPROVER",
                table: "TB_PERFIS_VENDA",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<float>(
                name: "VL_VOLUME_CONTRATO",
                table: "TB_PERFIS",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "VL_VOLUME_COMPLEMENTO",
                table: "TB_PERFIS",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME",
                table: "TB_PERFIS",
                type: "decimal(9, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "VL_PRECO",
                table: "TB_PERFIS",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_PRAZO",
                table: "TB_PERFIS",
                type: "decimal(38, 0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ST_PROVISION_APPROVER",
                table: "TB_PERFIS_VENDA");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_SUBPRODUTO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_DERIVATIVO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_ORDEM_CONTRATO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_CONTRATO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_COMPLEMENTO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME",
                table: "TB_PERFIS_VENDA",
                type: "decimal(38, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VALOR_COMPLEMENTO_PRECO",
                table: "TB_PERFIS_VENDA",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "VL_PRAZO",
                table: "TB_PERFIS_VENDA",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38, 0)");

            migrationBuilder.AlterColumn<int>(
                name: "VL_MAX_PERIODO_CONTRATO_ME",
                table: "TB_PERFIS_VENDA",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)");

            migrationBuilder.AlterColumn<int>(
                name: "VL_MAX_PERIODO_CONTRATO_MI",
                table: "TB_PERFIS_VENDA",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)");

            migrationBuilder.AddColumn<bool>(
                name: "ContractPriceApprover",
                table: "TB_PERFIS_VENDA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_CONTRATO",
                table: "TB_PERFIS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_VOLUME_COMPLEMENTO",
                table: "TB_PERFIS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "VL_VOLUME",
                table: "TB_PERFIS",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VL_PRECO",
                table: "TB_PERFIS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "VL_PRAZO",
                table: "TB_PERFIS",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38, 0)");
        }
    }
}
