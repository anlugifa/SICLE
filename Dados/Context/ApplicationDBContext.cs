using System;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.Extensions.Logging;
using Sicle.Dados.Context.Config.Acessos;
using Sicle.Dados.Context.Config.Contratos;
using Dominio.Entidades.Contrato;

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
            //acessos
            ConfigConfiguracao.Config(model);
            ConfigUsuario.Config(model);
            ConfigPerfil.Config(model);
            ConfigAssociacaoUsuarioPerfil.Config(model);
            ConfigPerfilVenda.Config(model);
            ConfigAssociacaoUsuarioPerfilVenda.Config(model);
            ConfigGrupoUsuario.Config(model);
            ConfigAssociacaoGrupoUsuario.Config(model);

            //contratos
            ConfigBroker.Config(model);
            ConfigContratoVenda.Config(model);
        }

        public DbSet<Product> Produtos { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PerfilVenda> PerfisVendas { get; set; }
        public DbSet<GrupoUsuario> GruposUsuarios { get; set; }
        public DbSet<AssociacaoGrupoUsuario> AssociacaoGruposUsuarios { get; set; }
        public DbSet<AssociacaoUsuarioPerfil> AssociacaoUsuarioPerfis { get; set; }
        public DbSet<AssociacaoUsuarioPerfilVenda> AssociacaoUsuarioPerfilVendas { get; set; }

        public DbSet<ContratoVenda> ContratosVendas { get; set; }
    }
}
