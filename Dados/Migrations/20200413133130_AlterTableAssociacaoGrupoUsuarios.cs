using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class AlterTableAssociacaoGrupoUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_USUARIOS_CD_SEQ_GRUPOUSUARIO",
                table: "TB_USUARIOS_GRUPOS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_GRUPOS_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_GRUPOS");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_GRUPOS_USUARIOS_CD_SEQ_GRUPOUSUARIO",
                table: "TB_USUARIOS_GRUPOS",
                column: "CD_SEQ_GRUPOUSUARIO",
                principalTable: "TB_GRUPOS_USUARIOS",
                principalColumn: "CD_SEQ_GRUPOUSUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_GRUPOS",
                column: "CD_SEQ_USUARIO",
                principalTable: "TB_USUARIOS",
                principalColumn: "CD_SEQ_USUARIO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_GRUPOS_USUARIOS_CD_SEQ_GRUPOUSUARIO",
                table: "TB_USUARIOS_GRUPOS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_GRUPOS");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_USUARIOS_CD_SEQ_GRUPOUSUARIO",
                table: "TB_USUARIOS_GRUPOS",
                column: "CD_SEQ_GRUPOUSUARIO",
                principalTable: "TB_USUARIOS",
                principalColumn: "CD_SEQ_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_GRUPOS_TB_GRUPOS_USUARIOS_CD_SEQ_USUARIO",
                table: "TB_USUARIOS_GRUPOS",
                column: "CD_SEQ_USUARIO",
                principalTable: "TB_GRUPOS_USUARIOS",
                principalColumn: "CD_SEQ_GRUPOUSUARIO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
