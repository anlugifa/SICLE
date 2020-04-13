using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class TabelaAcessos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileLevel",
                table: "TB_PERFIS_VENDA",
                newName: "TP_NIVEL_PERFIL");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "TB_PERFIS",
                newName: "SG_RATING");

            migrationBuilder.AddColumn<bool>(
                name: "ST_PROVISION_APPROVER",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "VL_MAX_PERIODO_CONTRATO",
                table: "TB_PERFIS",
                type: "decimal(10,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VL_MAX_PERIODO_IMPORTACAO",
                table: "TB_PERFIS",
                type: "decimal(10,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TP_NIVEL_PERFIL",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "VL_PRAZO_ENERGIA",
                table: "TB_PERFIS",
                type: "decimal(10,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "VL_PRECO_ENERGIA",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_COMPLEMENTO_ENERGIA",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_ENERGIA",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<decimal>(
                name: "VL_VOLUME_CONTRATO_ENERGIA",
                table: "TB_PERFIS",
                type: "decimal(9,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_IMPORTACAO",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_COMPRAS_DERIVATIVOS",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_SUBPRODUTOS",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_DERIVATIVOS",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VL_VOLUME_COMPRA_SUBPRODUTOS",
                table: "TB_PERFIS",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ST_PROVISION_APPROVER",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_MAX_PERIODO_CONTRATO",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_MAX_PERIODO_IMPORTACAO",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "TP_NIVEL_PERFIL",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_PRAZO_ENERGIA",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_PRECO_ENERGIA",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_COMPLEMENTO_ENERGIA",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_ENERGIA",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_CONTRATO_ENERGIA",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_IMPORTACAO",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_COMPRAS_DERIVATIVOS",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_SUBPRODUTOS",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_DERIVATIVOS",
                table: "TB_PERFIS");

            migrationBuilder.DropColumn(
                name: "VL_VOLUME_COMPRA_SUBPRODUTOS",
                table: "TB_PERFIS");

            migrationBuilder.RenameColumn(
                name: "TP_NIVEL_PERFIL",
                table: "TB_PERFIS_VENDA",
                newName: "ProfileLevel");

            migrationBuilder.RenameColumn(
                name: "SG_RATING",
                table: "TB_PERFIS",
                newName: "Rating");
        }
    }
}
