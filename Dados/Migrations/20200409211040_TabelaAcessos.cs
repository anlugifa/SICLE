using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class TabelaAcessos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_GRUPOS_USUARIOS",
                columns: table => new
                {
                    CD_SEQ_GRUPOUSUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_GRUPOUSUARIO = table.Column<string>(maxLength: 25, nullable: false),
                    DS_GRUPOUSUARIO = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GRUPOS_USUARIOS", x => x.CD_SEQ_GRUPOUSUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERFIS",
                columns: table => new
                {
                    CD_SEQ_PERFIL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_PERFIL = table.Column<string>(maxLength: 16, nullable: false),
                    DS_PERFIL = table.Column<string>(maxLength: 20, nullable: true),
                    VL_VOLUME = table.Column<int>(nullable: false),
                    VL_PRAZO = table.Column<int>(nullable: false),
                    VL_PRECO = table.Column<decimal>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    VL_VOLUME_CONTRATO = table.Column<decimal>(nullable: false),
                    VL_VOLUME_COMPLEMENTO = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIS", x => x.CD_SEQ_PERFIL);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERFIS_VENDA",
                columns: table => new
                {
                    CD_SEQ_PERFIL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_PERFIL = table.Column<string>(maxLength: 16, nullable: false),
                    DS_PERFIL = table.Column<string>(maxLength: 20, nullable: true),
                    VL_VOLUME = table.Column<decimal>(nullable: false),
                    VL_VOLUME_CONTRATO = table.Column<decimal>(nullable: false),
                    VL_VOLUME_COMPLEMENTO = table.Column<decimal>(nullable: false),
                    VL_VALOR_COMPLEMENTO_PRECO = table.Column<decimal>(nullable: false),
                    VL_VOLUME_ORDEM_CONTRATO = table.Column<decimal>(nullable: false),
                    VL_VOLUME_DERIVATIVO = table.Column<decimal>(nullable: false),
                    VL_VOLUME_SUBPRODUTO = table.Column<decimal>(nullable: false),
                    VL_PRAZO = table.Column<int>(nullable: false),
                    VL_MAX_PERIODO_CONTRATO_ME = table.Column<int>(nullable: false),
                    VL_MAX_PERIODO_CONTRATO_MI = table.Column<int>(nullable: false),
                    ContractPriceApprover = table.Column<bool>(nullable: false),
                    ST_PROVISION_APPROVER = table.Column<bool>(nullable: false),
                    ST_FORECAST_APPROVER = table.Column<bool>(nullable: false),
                    ST_YNOR_FROM_YCNR_APPROVER = table.Column<bool>(nullable: false),
                    ST_COMPLEMENT_APPROVER = table.Column<bool>(nullable: false),
                    ST_ENDOSSO_FINANCAS = table.Column<bool>(nullable: false),
                    ProfileLevel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIS_VENDA", x => x.CD_SEQ_PERFIL);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    CD_SEQ_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_LOGIN = table.Column<string>(maxLength: 6, nullable: false),
                    NM_USUARIO = table.Column<string>(maxLength: 50, nullable: false),
                    NM_USUARIO_SGP = table.Column<string>(maxLength: 50, nullable: false),
                    DS_EMAIL = table.Column<string>(nullable: false),
                    TP_PERFIL = table.Column<bool>(nullable: false),
                    ST_ATIVO = table.Column<bool>(nullable: false),
                    DS_TRADER_COMBUSTIVEL = table.Column<bool>(nullable: false),
                    DS_TRADER_ENERGIA = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.CD_SEQ_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS_GRUPOS",
                columns: table => new
                {
                    CD_SEQ_USUARIO = table.Column<int>(nullable: false),
                    CD_SEQ_GRUPOUSUARIO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS_GRUPOS", x => new { x.CD_SEQ_USUARIO, x.CD_SEQ_GRUPOUSUARIO });
                    table.ForeignKey(
                        name: "FK_TB_USUARIOS_GRUPOS_TB_USUARIOS_CD_SEQ_GRUPOUSUARIO",
                        column: x => x.CD_SEQ_GRUPOUSUARIO,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "CD_SEQ_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USUARIOS_GRUPOS_TB_GRUPOS_USUARIOS_CD_SEQ_USUARIO",
                        column: x => x.CD_SEQ_USUARIO,
                        principalTable: "TB_GRUPOS_USUARIOS",
                        principalColumn: "CD_SEQ_GRUPOUSUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS_PERFIS",
                columns: table => new
                {
                    CD_SEQ_USUARIO = table.Column<int>(nullable: false),
                    CD_SEQ_PERFIL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS_PERFIS", x => new { x.CD_SEQ_USUARIO, x.CD_SEQ_PERFIL });
                    table.ForeignKey(
                        name: "FK_TB_USUARIOS_PERFIS_TB_USUARIOS_CD_SEQ_PERFIL",
                        column: x => x.CD_SEQ_PERFIL,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "CD_SEQ_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USUARIOS_PERFIS_TB_PERFIS_CD_SEQ_USUARIO",
                        column: x => x.CD_SEQ_USUARIO,
                        principalTable: "TB_PERFIS",
                        principalColumn: "CD_SEQ_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS_PERFIS_VENDA",
                columns: table => new
                {
                    CD_SEQ_USUARIO = table.Column<int>(nullable: false),
                    CD_SEQ_PERFIL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS_PERFIS_VENDA", x => new { x.CD_SEQ_USUARIO, x.CD_SEQ_PERFIL });
                    table.ForeignKey(
                        name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_USUARIOS_CD_SEQ_PERFIL",
                        column: x => x.CD_SEQ_PERFIL,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "CD_SEQ_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_PERFIS_VENDA_CD_SEQ_USUARIO",
                        column: x => x.CD_SEQ_USUARIO,
                        principalTable: "TB_PERFIS_VENDA",
                        principalColumn: "CD_SEQ_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_GRUPOS_CD_SEQ_GRUPOUSUARIO",
                table: "TB_USUARIOS_GRUPOS",
                column: "CD_SEQ_GRUPOUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_PERFIS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS",
                column: "CD_SEQ_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_PERFIS_VENDA_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS_VENDA",
                column: "CD_SEQ_PERFIL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USUARIOS_GRUPOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS_PERFIS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS_PERFIS_VENDA");

            migrationBuilder.DropTable(
                name: "TB_GRUPOS_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_PERFIS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "TB_PERFIS_VENDA");
        }
    }
}
