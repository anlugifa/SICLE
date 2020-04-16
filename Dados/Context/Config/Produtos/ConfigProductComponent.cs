using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Produtos
{
    public class ConfigProductComponent
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<ProductComponent>(t =>
            {
                t.ToTable("TB_COMPONENTES_PRODUTO");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_COMPONENTES");
                t.Property(p => p.ProductId).HasColumnName("CD_SEQ_PRODUTO");
                t.Property(p => p.ComponentId).HasColumnName("CD_SEQ_PROD_COMP");
                t.Property(p => p.PlantId).HasColumnName("CD_SEQ_LOCALIDADE");
                t.Property(p => p.CodAACL).HasColumnName("CD_AACL");
                t.Property(p => p.Bom).HasColumnName("CD_BOM");
                t.Property(p => p.BomAL).HasColumnName("CD_BOMAL");
                t.Property(p => p.Quantity).HasColumnName("QT_PRODUTO");
            });

            model.Entity<ProductComponent>()
                        .HasOne(b => b.Product)
                        .WithMany()
                        .HasForeignKey(f => f.ProductId);

            model.Entity<ProductComponent>()
                        .HasOne(b => b.Component)
                        .WithMany()
                        .HasForeignKey(f => f.ComponentId);

            model.Entity<ProductComponent>()
                        .HasOne(b => b.Plant)
                        .WithMany()
                        .HasForeignKey(f => f.PlantId);
        }
    }
}
