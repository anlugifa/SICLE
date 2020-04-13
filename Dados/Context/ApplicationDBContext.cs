using System;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.Extensions.Logging;

namespace Dados
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Produto>().ToTable("Produto");
            model.Entity<Categoria>().ToTable("Categoria");

            ConfigureTableConfiguracao(model);
            ConfigureTableUsuario(model);
            ConfigureTablePerfil(model);
            ConfigureTableAssociacaoUsuarioPerfil(model);
            ConfigureTablePerfilVenda(model);
            ConfigureTableAssociacaoUsuarioPerfilVenda(model);
            ConfigureTableGrupoUsuario(model);
            ConfigureTableAssociacaoGrupoUsuario(model);
        }

        internal void ConfigureTableUsuario(ModelBuilder model)
        {
            model.Entity<Usuario>(t =>
            {
                t.ToTable("TB_USUARIOS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_USUARIO");
                t.Property(p => p.Matricula).HasColumnName("DS_LOGIN");
                t.Property(p => p.Nome).HasColumnName("NM_USUARIO");
                t.Property(p => p.NomeSGP).HasColumnName("NM_USUARIO_SGP");
                t.Property(p => p.Email).HasColumnName("DS_EMAIL");
                t.Property(p => p.IsPerfil).HasColumnName("TP_PERFIL");
                t.Property(p => p.IsAtivo).HasColumnName("ST_ATIVO");
                t.Property(p => p.IsTraderComb).HasColumnName("DS_TRADER_COMBUSTIVEL");
                t.Property(p => p.IsTraderEAB).HasColumnName("DS_TRADER_ENERGIA");

            });
        }

        internal void ConfigureTablePerfil(ModelBuilder model)
        {
            model.Entity<Perfil>(t =>
            {
                t.ToTable("TB_PERFIS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_PERFIL");
                t.Property(p => p.Code).HasColumnName("CD_PERFIL");
                t.Property(p => p.Nome).HasColumnName("DS_PERFIL");
                t.Property(p => p.Volume).HasColumnName("VL_VOLUME").HasColumnType("decimal(9, 2)");
                t.Property(p => p.Prazo).HasColumnName("VL_PRAZO").HasColumnType("decimal(38, 0)");
                t.Property(p => p.Preco).HasColumnName("VL_PRECO");
                t.Property(p => p.VolumeContrato).HasColumnName("VL_VOLUME_CONTRATO");
                t.Property(p => p.VolumeComplemento).HasColumnName("VL_VOLUME_COMPLEMENTO");

                t.Property(p => p.VlVolumeEnergia).HasColumnName("VL_VOLUME_CONTRATO_ENERGIA").HasColumnType("decimal(9,2)");
                t.Property(p => p.VlVolumeContratoEnergia).HasColumnName("VL_VOLUME_ENERGIA");
                t.Property(p => p.VlVolumeImportacao).HasColumnName("VL_VOLUME_IMPORTACAO");
                t.Property(p => p.VlPrecoEnergia).HasColumnName("VL_PRECO_ENERGIA");
                t.Property(p => p.VlPrazoEnergia).HasColumnName("VL_PRAZO_ENERGIA").HasColumnType("decimal(10,0)");
                t.Property(p => p.VlVolumeComplementoEnergia).HasColumnName("VL_VOLUME_COMPLEMENTO_ENERGIA");
                t.Property(p => p.VlVolumeMaxPurchaseDetivatives).HasColumnName("VL_VOLUME_DERIVATIVOS");
                t.Property(p => p.VlVolumeMaxOrderDerivatives).HasColumnName("VL_VOLUME_COMPRAS_DERIVATIVOS");
                t.Property(p => p.VlVolumeMaxOrderSubproduct).HasColumnName("VL_VOLUME_SUBPRODUTOS");
                t.Property(p => p.VlVolumeMaxPurchaseSubproduct).HasColumnName("VL_VOLUME_COMPRA_SUBPRODUTOS");
                t.Property(p => p.MaxPeriodImportContract).HasColumnName("VL_MAX_PERIODO_IMPORTACAO").HasColumnType("decimal(10,0)");
                t.Property(p => p.MaxPeriodContract).HasColumnName("VL_MAX_PERIODO_CONTRATO").HasColumnType("decimal(10,0)");
                t.Property(p => p.MaxCreditLimit).HasColumnName("VL_MAX_CREDIT_LIMIT").HasColumnType("decimal(38,0)");

                t.Property(p => p.IsProvisionApprover).HasColumnName("ST_PROVISION_APPROVER");
                
                t.Property(p => p.ProfileLevel).HasColumnName("TP_NIVEL_PERFIL")                    
                    .HasConversion(
                        v => v.ToString(),
                        v => (ProfileLevel)Enum.Parse(typeof(ProfileLevel), v));

                t.Property(p => p.Rating).HasColumnName("SG_RATING") 
                    .HasConversion(
                        v => v.ToString(),
                        v => (PurchaseRating)Enum.Parse(typeof(PurchaseRating), v));
            });
        }

        

        internal void ConfigureTableAssociacaoUsuarioPerfil(ModelBuilder model)
        {
            model.Entity<AssociacaoUsuarioPerfil>(t =>
           {
               t.ToTable("TB_USUARIOS_PERFIS");
               t.HasKey(o => new { o.UsuarioId, o.PerfilId });
               t.Property(p => p.UsuarioId).HasColumnName("CD_SEQ_USUARIO");
               t.Property(p => p.PerfilId).HasColumnName("CD_SEQ_PERFIL");
           });

            model.Entity<AssociacaoUsuarioPerfil>()
                        .HasOne(b => b.Usuario)
                        .WithMany(b => b.Perfis)
                        .HasForeignKey(b => b.PerfilId);

            model.Entity<AssociacaoUsuarioPerfil>()
                        .HasOne(b => b.Perfil)
                        .WithMany(b => b.Usuarios)
                        .HasForeignKey(b => b.UsuarioId);
        }

        internal void ConfigureTablePerfilVenda(ModelBuilder model)
        {
            model.Entity<PerfilVenda>(t =>
            {
                t.ToTable("TB_PERFIS_VENDA");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_PERFIL");
                t.Property(p => p.Code).HasColumnName("CD_PERFIL");
                t.Property(p => p.Nome).HasColumnName("DS_PERFIL");
                t.Property(p => p.VlVolume).HasColumnName("VL_VOLUME").HasColumnType("decimal(9, 2)");

                t.Property(p => p.VlPrazo).HasColumnName("VL_PRAZO").HasColumnType("decimal(38, 0)");
                t.Property(p => p.VlVolumeContrato).HasColumnName("VL_VOLUME_CONTRATO").HasColumnType("decimal(9, 2)");
                t.Property(p => p.VlVolumeComplemento).HasColumnName("VL_VOLUME_COMPLEMENTO").HasColumnType("decimal(9, 2)");
                t.Property(p => p.VlVolumeMaxOrderDerivatives).HasColumnName("VL_VOLUME_DERIVATIVO");
                t.Property(p => p.VlVolumeMaxOrderSubproduct).HasColumnName("VL_VOLUME_SUBPRODUTO");
                t.Property(p => p.VlValorComplementoPreco).HasColumnName("VL_VALOR_COMPLEMENTO_PRECO");
                t.Property(p => p.VlVolumeMaxOrderContrato).HasColumnName("VL_VOLUME_ORDEM_CONTRATO").HasColumnType("decimal(9, 2)");
                t.Property(p => p.MaxPeriodSaleForeignContract).HasColumnName("VL_MAX_PERIODO_CONTRATO_ME").HasColumnType("decimal(10, 0)");
                t.Property(p => p.MaxPeriodSaleContract).HasColumnName("VL_MAX_PERIODO_CONTRATO_MI").HasColumnType("decimal(10, 0)");

                t.Property(p => p.IsProvisionApprover).HasColumnName("ST_PROVISION_APPROVER");
                t.Property(p => p.IsForecastApprover).HasColumnName("ST_FORECAST_APPROVER");
                t.Property(p => p.IsYnorFromYcnrApprover).HasColumnName("ST_YNOR_FROM_YCNR_APPROVER");
                t.Property(p => p.IsComplementApprover).HasColumnName("ST_COMPLEMENT_APPROVER");
                t.Property(p => p.IsContractPriceApprover).HasColumnName("ST_CONTRACT_PRICE_APPROVER");
                t.Property(p => p.IsFinanceEndorsement).HasColumnName("ST_ENDOSSO_FINANCAS");                

                t.Property(p => p.ProfileLevel).HasColumnName("TP_NIVEL_PERFIL")                    
                    .HasConversion(
                        v => v.ToString(),
                        v => (ProfileLevel)Enum.Parse(typeof(ProfileLevel), v));
            });
        }

         internal void ConfigureTableAssociacaoUsuarioPerfilVenda(ModelBuilder model)
        {
            model.Entity<AssociacaoUsuarioPerfilVenda>(t =>
           {
               t.ToTable("TB_USUARIOS_PERFIS_VENDA");
               t.HasKey(o => new { o.UsuarioId, o.PerfilVendaId });
               t.Property(p => p.UsuarioId).HasColumnName("CD_SEQ_USUARIO");
               t.Property(p => p.PerfilVendaId).HasColumnName("CD_SEQ_PERFIL");
           });

            model.Entity<AssociacaoUsuarioPerfilVenda>()
                        .HasOne(b => b.Usuario)
                        .WithMany(b => b.PerfilVendas)
                        .HasForeignKey(b => b.PerfilVendaId);

            model.Entity<AssociacaoUsuarioPerfilVenda>()
                        .HasOne(b => b.PerfilVenda)
                        .WithMany(b => b.Usuarios)
                        .HasForeignKey(b => b.UsuarioId);
        }

        internal void ConfigureTableGrupoUsuario(ModelBuilder model)
        {
            model.Entity<GrupoUsuario>(t =>
            {
                t.ToTable("TB_GRUPOS_USUARIOS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_GRUPOUSUARIO");
                t.Property(p => p.Code).HasColumnName("CD_GRUPOUSUARIO");
                t.Property(p => p.Nome).HasColumnName("DS_GRUPOUSUARIO");
            });
        }

        internal void ConfigureTableAssociacaoGrupoUsuario(ModelBuilder model)
        {
            model.Entity<AssociacaoGrupoUsuario>(t =>
           {
               t.ToTable("TB_USUARIOS_GRUPOS");
               t.HasKey(o => new { o.UsuarioId, o.GrupoUsuarioId });
               t.Property(p => p.UsuarioId).HasColumnName("CD_SEQ_USUARIO");
               t.Property(p => p.GrupoUsuarioId).HasColumnName("CD_SEQ_GRUPOUSUARIO");
           });

            model.Entity<AssociacaoGrupoUsuario>()
                        .HasOne(b => b.Usuario)
                        .WithMany(b => b.Grupos)
                        .HasForeignKey(b => b.UsuarioId);

            model.Entity<AssociacaoGrupoUsuario>()
                        .HasOne(b => b.Grupo)
                        .WithMany(b => b.Usuarios)
                        .HasForeignKey(b => b.GrupoUsuarioId);
        }
        internal void ConfigureTableConfiguracao(ModelBuilder model)
        {
            model.Entity<Configuracao>(t =>
            {
                t.ToTable("TB_CONFIGURACOES");
                t.HasKey(p => p.Code);
                t.Property(p => p.Code).HasColumnName("CD_CONFIGURACAO");
                t.Property(p => p.Value).HasColumnName("VL_CONFIGURACAO");
            });
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PerfilVenda> PerfisVendas { get; set; }
        public DbSet<GrupoUsuario> GruposUsuarios { get; set; }
        public DbSet<AssociacaoGrupoUsuario> AssociacaoGruposUsuarios { get; set; }
    }
}
