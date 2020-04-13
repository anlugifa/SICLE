using System;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.Extensions.Logging;
using Sicle.Dados.Context.Config;

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

            ConfigConfiguracao.Config(model);
            ConfigUsuario.Config(model);
            ConfigPerfil.Config(model);
            ConfigAssociacaoUsuarioPerfil.Config(model);
            ConfigPerfilVenda.Config(model);
            ConfigAssociacaoUsuarioPerfilVenda.Config(model);
            ConfigGrupoUsuario.Config(model);
            ConfigAssociacaoGrupoUsuario.Config(model);
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
