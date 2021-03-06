﻿#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Infra;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Sicle.Dados.Context.Config.Acessos;
using Sicle.Dados.Context.Config.Contratos;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;
using Dominio.Entidades.Localidades;
using Sicle.Dados.Context.Config.Localidades;
using Sicle.Dados.Context.Config.Produtos;
using Sicle.Dados.Context.Config.Pricing;
using Dominio.Entidades.Pricing;
using Microsoft.Extensions.Configuration;
using Sicle.Dados.Context.Config.Infra;
using System.IO;


namespace Dados
{
    public class ApplicationDBContext : DbContext
    {
        private IConfiguration Configuration;

        public ApplicationDBContext() : base()
        {           
           var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            this.Configuration = builder.Build();
        }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();     

            var connString = Configuration.GetConnectionString("Sicle");     
            
            optionsBuilder.UseOracle(connString, b =>
                    b.UseOracleSQLCompatibility("11")
            );

            if (Configuration.GetValue("TraceSQL", "False").Equals("True"))
            {                  
                ILoggerFactory factory = new LoggerFactory(new[] { 
                            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()  });

                optionsBuilder.UseLoggerFactory(factory).EnableSensitiveDataLogging();                
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //infra
            ConfigConfiguracao.Config(model);
            //ConfigError.Config(model);
            
            //acessos            
            ConfigUsuario.Config(model);
            ConfigPerfil.Config(model);
            ConfigAssociacaoUsuarioPerfil.Config(model);
            ConfigPerfilVenda.Config(model);
            ConfigAssociacaoUsuarioPerfilVenda.Config(model);
            ConfigGrupoUsuario.Config(model);
            ConfigAssociacaoGrupoUsuario.Config(model);

            //contratos
            ConfigBroker.Config(model);
            ConfigMasterSaleContract.Config(model);

            ConfigEvaluatedContract.Config(model);
            ConfigApprovalContract.Config(model);
            ConfigSaleContract.Config(model);
            ConfigPaymentTerm.Config(model);
            ConfigProductGroup.Config(model);

            ConfigProduct.Config(model);
            ConfigProductComponent.Config(model);
            ConfigSpecialUnit.Config(model);

            ConfigProductInPlant.Config(model);
            ConfigClientGroup.Config(model);
            ConfigClient.Config(model);
            ConfigPlant.Config(model);
            ConfigLocalidadeGeografica.Config(model);
            ConfigRegiao.Config(model);
            ConfigLocalidades.Config(model);
            
            ConfigCompany.Config(model);
            ConfigRestricaoCargaDescarga.Config(model);
           
            ConfigCGCRegister.Config(model);

            ConfigSaleContractQuota.Config(model);
            ConfigSaleContractVolumePeriod.Config(model);
            ConfigSaleContractPricingRule.Config(model);
            ConfigSaleContractPricingPeriod.Config(model);
            ConfigMapPricingRule_VolumePeriod.Config(model);

            ConfigEsalqDescription.Config(model);
            ConfigOpenBookCost.Config(model);
            ConfigPrecoPBDescription.Config(model);
            ConfigPrecoPBModal.Config(model);
            ConfigPrecoPBProduct.Config(model);
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

        public DbSet<MasterSaleContract> ContratosVendasMestres { get; set; }
        public DbSet<SaleContract> ContratosVendas { get; set; }
        public DbSet<ApprovalSaleContract> ApprovalSaleContracts { get; set; }
        public DbSet<EvaluatedSaleContract> EvaluatedSaleContracts { get; set; }

        public DbSet<Broker> Brokers { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComponent> ProductComponents { get; set; }
        public DbSet<SpecialUnit> SpecialUnits { get; set; }

        public DbSet<ProductInPlant> ProductInPlants { get; set; }        
        
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RestricaoCargaDescarga> RestricoesCargasDescargas { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CGCRegister> CGCRegisters { get; set; }

        public DbSet<LocalidadeGeografica> LocalidadeGeograficas { get; set; }
        public DbSet<Localidade> Localidades { get; set; }

        public DbSet<SaleContractQuota> SaleContractQuotas { get; set; }
        public DbSet<SaleContractVolumePeriod> SaleContractVolumePeriods { get; set; }
        public DbSet<SaleContractPricingRule> SaleContractPricingRules { get; set; }
        public DbSet<SaleContractPricingPeriod> SaleContractPricingPeriods { get; set; }

        public DbSet<OpenBookCost> OpenBookCosts { get; set; }
        public DbSet<EsalqDescription> EsalDescriptions { get; set; }
        public DbSet<PrecoPBDescription> PrecoPBDescriptions { get; set; }
        public DbSet<PrecoPBModal> PrecoPBModals { get; set; }
        public DbSet<PrecoPBProduct> PrecoPBProducts { get; set; }
    }
}
