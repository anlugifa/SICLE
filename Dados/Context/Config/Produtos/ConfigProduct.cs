using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Produtos
{
    public class ConfigProduct
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Product>(t =>
            {
                t.ToTable("TB_PRODUTOS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_PRODUTO");
                t.Property(p => p.Code).HasColumnName("CD_PRODUTO");
                t.Property(p => p.CodeCL).HasColumnName("CD_PRODUTO_CL");
                t.Property(p => p.CodeH1).HasColumnName("CD_H1");
                t.Property(p => p.CodeH2).HasColumnName("CD_H2"); 
                t.Property(p => p.CodeH3).HasColumnName("CD_H3"); 
                t.Property(p => p.DescriptionH1).HasColumnName("DS_H1");
                t.Property(p => p.DescriptionH2).HasColumnName("DS_H2");         
                t.Property(p => p.DescriptionH3).HasColumnName("DS_H3"); 
                t.Property(p => p.Description).HasColumnName("DS_PRODUTO"); 
                t.Property(p => p.ProductionPrize).HasColumnName("VL_PREMIO_PRODUCAO"); 

                t.Property(p => p.IsReference).HasColumnName("ST_PRODUTO_CHAVE"); 
                t.Property(p => p.IsImported).HasColumnName("ST_PRODUTO_IMPORTADO");                 
                t.Property(p => p.IsScaProfile).HasColumnName("ST_PERFIL_SCA"); 
                t.Property(p => p.IsActive).HasColumnName("ST_ATIVO"); 
                t.Property(p => p.IsAnidroCorante).HasColumnName("ST_ANIDRO_SEM_CORANTE");

                t.Property(p => p.SpecialUnitId).HasColumnName("CD_UNIDADE_ESPECIAL"); 
                t.Property(p => p.ProductGroupId).HasColumnName("CD_SEQ_GRUPO_PRODUTO"); 

                t.Property(p => p.Purpose).HasColumnName("DS_PROPOSITO"); 
                t.Property(p => p.ProductEsalqType).HasColumnName("TP_PRODUTO_ESALQ"); 
                t.Property(p => p.PurchaseSaleType).HasColumnName("TP_OPERACAO");         

            });

            model.Entity<Product>()
                        .HasOne(b => b.SpecialUnit)
                        .WithMany()
                        .HasForeignKey(f => f.SpecialUnitId);

            model.Entity<Product>()
                        .HasOne(b => b.ProductGroup)
                        .WithMany(b => b.Products)
                        .HasForeignKey(f => f.ProductGroupId);

            model.Entity<Product>()
                        .HasMany(b => b.Components)
                        .WithOne(b => b.Product)
                        .HasForeignKey(f => f.ProductId);
        }
    }
}
