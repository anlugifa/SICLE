﻿// <auto-generated />
using Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dados.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20200410182914_TabelaUsuarioAlterColumnMatricula")]
    partial class TabelaUsuarioAlterColumnMatricula
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Acesso.AssociacaoGrupoUsuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnName("CD_SEQ_USUARIO")
                        .HasColumnType("int");

                    b.Property<int>("GrupoUsuarioId")
                        .HasColumnName("CD_SEQ_GRUPOUSUARIO")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "GrupoUsuarioId");

                    b.HasIndex("GrupoUsuarioId");

                    b.ToTable("TB_USUARIOS_GRUPOS");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.AssociacaoUsuarioPerfil", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnName("CD_SEQ_USUARIO")
                        .HasColumnType("int");

                    b.Property<int>("PerfilId")
                        .HasColumnName("CD_SEQ_PERFIL")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "PerfilId");

                    b.HasIndex("PerfilId");

                    b.ToTable("TB_USUARIOS_PERFIS");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.AssociacaoUsuarioPerfilVenda", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnName("CD_SEQ_USUARIO")
                        .HasColumnType("int");

                    b.Property<int>("PerfilVendaId")
                        .HasColumnName("CD_SEQ_PERFIL")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "PerfilVendaId");

                    b.HasIndex("PerfilVendaId");

                    b.ToTable("TB_USUARIOS_PERFIS_VENDA");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.GrupoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CD_SEQ_GRUPOUSUARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("CD_GRUPOUSUARIO")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("DS_GRUPOUSUARIO")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TB_GRUPOS_USUARIOS");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CD_SEQ_PERFIL")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("CD_PERFIL")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<bool>("IsProvisionApprover")
                        .HasColumnName("ST_PROVISION_APPROVER")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxPeriodContract")
                        .HasColumnName("VL_MAX_PERIODO_CONTRATO")
                        .HasColumnType("decimal(10,0)");

                    b.Property<decimal>("MaxPeriodImportContract")
                        .HasColumnName("VL_MAX_PERIODO_IMPORTACAO")
                        .HasColumnType("decimal(10,0)");

                    b.Property<string>("Nome")
                        .HasColumnName("DS_PERFIL")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<decimal>("Prazo")
                        .HasColumnName("VL_PRAZO")
                        .HasColumnType("decimal(38, 0)");

                    b.Property<float>("Preco")
                        .HasColumnName("VL_PRECO")
                        .HasColumnType("real");

                    b.Property<string>("ProfileLevel")
                        .IsRequired()
                        .HasColumnName("TP_NIVEL_PERFIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnName("SG_RATING")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VlPrazoEnergia")
                        .HasColumnName("VL_PRAZO_ENERGIA")
                        .HasColumnType("decimal(10,0)");

                    b.Property<float>("VlPrecoEnergia")
                        .HasColumnName("VL_PRECO_ENERGIA")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeComplementoEnergia")
                        .HasColumnName("VL_VOLUME_COMPLEMENTO_ENERGIA")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeContratoEnergia")
                        .HasColumnName("VL_VOLUME_ENERGIA")
                        .HasColumnType("real");

                    b.Property<decimal>("VlVolumeEnergia")
                        .HasColumnName("VL_VOLUME_CONTRATO_ENERGIA")
                        .HasColumnType("decimal(9,2)");

                    b.Property<float>("VlVolumeImportacao")
                        .HasColumnName("VL_VOLUME_IMPORTACAO")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeMaxOrderDerivatives")
                        .HasColumnName("VL_VOLUME_COMPRAS_DERIVATIVOS")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeMaxOrderSubproduct")
                        .HasColumnName("VL_VOLUME_SUBPRODUTOS")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeMaxPurchaseDetivatives")
                        .HasColumnName("VL_VOLUME_DERIVATIVOS")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeMaxPurchaseSubproduct")
                        .HasColumnName("VL_VOLUME_COMPRA_SUBPRODUTOS")
                        .HasColumnType("real");

                    b.Property<decimal>("Volume")
                        .HasColumnName("VL_VOLUME")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<float>("VolumeComplemento")
                        .HasColumnName("VL_VOLUME_COMPLEMENTO")
                        .HasColumnType("real");

                    b.Property<float>("VolumeContrato")
                        .HasColumnName("VL_VOLUME_CONTRATO")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TB_PERFIS");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.PerfilVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CD_SEQ_PERFIL")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("CD_PERFIL")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<bool>("IsComplementApprover")
                        .HasColumnName("ST_COMPLEMENT_APPROVER")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContractPriceApprover")
                        .HasColumnName("ST_CONTRACT_PRICE_APPROVER")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinanceEndorsement")
                        .HasColumnName("ST_ENDOSSO_FINANCAS")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForecastApprover")
                        .HasColumnName("ST_FORECAST_APPROVER")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProvisionApprover")
                        .HasColumnName("ST_PROVISION_APPROVER")
                        .HasColumnType("bit");

                    b.Property<bool>("IsYnorFromYcnrApprover")
                        .HasColumnName("ST_YNOR_FROM_YCNR_APPROVER")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxPeriodSaleContract")
                        .HasColumnName("VL_MAX_PERIODO_CONTRATO_MI")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<decimal>("MaxPeriodSaleForeignContract")
                        .HasColumnName("VL_MAX_PERIODO_CONTRATO_ME")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<string>("Nome")
                        .HasColumnName("DS_PERFIL")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ProfileLevel")
                        .IsRequired()
                        .HasColumnName("TP_NIVEL_PERFIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VlPrazo")
                        .HasColumnName("VL_PRAZO")
                        .HasColumnType("decimal(38, 0)");

                    b.Property<float>("VlValorComplementoPreco")
                        .HasColumnName("VL_VALOR_COMPLEMENTO_PRECO")
                        .HasColumnType("real");

                    b.Property<decimal>("VlVolume")
                        .HasColumnName("VL_VOLUME")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal>("VlVolumeComplemento")
                        .HasColumnName("VL_VOLUME_COMPLEMENTO")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal>("VlVolumeContrato")
                        .HasColumnName("VL_VOLUME_CONTRATO")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<decimal>("VlVolumeMaxOrderContrato")
                        .HasColumnName("VL_VOLUME_ORDEM_CONTRATO")
                        .HasColumnType("decimal(9, 2)");

                    b.Property<float>("VlVolumeMaxOrderDerivatives")
                        .HasColumnName("VL_VOLUME_DERIVATIVO")
                        .HasColumnType("real");

                    b.Property<float>("VlVolumeMaxOrderSubproduct")
                        .HasColumnName("VL_VOLUME_SUBPRODUTO")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TB_PERFIS_VENDA");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CD_SEQ_USUARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("DS_EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAtivo")
                        .HasColumnName("ST_ATIVO")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPerfil")
                        .HasColumnName("TP_PERFIL")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTraderComb")
                        .HasColumnName("DS_TRADER_COMBUSTIVEL")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTraderEAB")
                        .HasColumnName("DS_TRADER_ENERGIA")
                        .HasColumnType("bit");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnName("DS_LOGIN")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NM_USUARIO")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NomeSGP")
                        .IsRequired()
                        .HasColumnName("NM_USUARIO_SGP")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIOS");
                });

            modelBuilder.Entity("Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Dominio.Entidades.Configuracao", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnName("CD_CONFIGURACAO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnName("VL_CONFIGURACAO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("TB_CONFIGURACOES");
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.AssociacaoGrupoUsuario", b =>
                {
                    b.HasOne("Dominio.Entidades.Acesso.Usuario", "Usuario")
                        .WithMany("Grupos")
                        .HasForeignKey("GrupoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Acesso.GrupoUsuario", "Grupo")
                        .WithMany("Usuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.AssociacaoUsuarioPerfil", b =>
                {
                    b.HasOne("Dominio.Entidades.Acesso.Usuario", "Usuario")
                        .WithMany("Perfis")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Acesso.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Acesso.AssociacaoUsuarioPerfilVenda", b =>
                {
                    b.HasOne("Dominio.Entidades.Acesso.Usuario", "Usuario")
                        .WithMany("PerfilVendas")
                        .HasForeignKey("PerfilVendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Acesso.PerfilVenda", "PerfilVenda")
                        .WithMany("Usuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("Dominio.Entidades.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
