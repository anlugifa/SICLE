using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class AlterTableAssociaUsuarioPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_USUARIOS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_PERFIS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_USUARIOS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_PERFIS_VENDA_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS_VENDA");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_PERFIS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS",
                column: "CD_SEQ_PERFIL",
                principalTable: "TB_PERFIS",
                principalColumn: "CD_SEQ_PERFIL",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS",
                column: "CD_SEQ_USUARIO",
                principalTable: "TB_USUARIOS",
                principalColumn: "CD_SEQ_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_PERFIS_VENDA_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS_VENDA",
                column: "CD_SEQ_PERFIL",
                principalTable: "TB_PERFIS_VENDA",
                principalColumn: "CD_SEQ_PERFIL",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS_VENDA",
                column: "CD_SEQ_USUARIO",
                principalTable: "TB_USUARIOS",
                principalColumn: "CD_SEQ_USUARIO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_PERFIS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_PERFIS_VENDA_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS_VENDA");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_USUARIOS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS",
                column: "CD_SEQ_PERFIL",
                principalTable: "TB_USUARIOS",
                principalColumn: "CD_SEQ_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_TB_PERFIS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS",
                column: "CD_SEQ_USUARIO",
                principalTable: "TB_PERFIS",
                principalColumn: "CD_SEQ_PERFIL",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_USUARIOS_CD_SEQ_PERFIL",
                table: "TB_USUARIOS_PERFIS_VENDA",
                column: "CD_SEQ_PERFIL",
                principalTable: "TB_USUARIOS",
                principalColumn: "CD_SEQ_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_PERFIS_VENDA_TB_PERFIS_VENDA_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_PERFIS_VENDA",
                column: "CD_SEQ_USUARIO",
                principalTable: "TB_PERFIS_VENDA",
                principalColumn: "CD_SEQ_PERFIL",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
