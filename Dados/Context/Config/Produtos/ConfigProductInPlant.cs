using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidade;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Produtos
{
    public class ConfigProductInPlant
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<ProductInPlant>(t =>
            {
                t.ToTable("TB_PRODUTOS_PLANTA");

                t.HasKey(p => new { p.PlantId, p.ProductId, p.Month, p.Year });

                t.Property(p => p.PlantId).HasColumnName("CD_SEQ_LOCALIDADE");
                t.Property(p => p.ProductId).HasColumnName("CD_SEQ_PRODUTO");
                t.Property(p => p.Month).HasColumnName("VL_MES");
                t.Property(p => p.Year).HasColumnName("VL_ANO");
                t.Property(p => p.MinimumCapacity).HasColumnName("QT_CAPACIDADEMINIMA");
                t.Property(p => p.MaximumCapacity).HasColumnName("QT_CAPACIDADEMAXIMA");
                t.Property(p => p.Target).HasColumnName("QT_ESTOQUEMAXIMOCLASTRO");
                t.Property(p => p.StockWheel).HasColumnName("QT_ESTOQUE_SOBRE_RODAS");
            });

            model.Entity<ProductInPlant>()
                    .HasOne(x => x.Plant)
                    .WithMany()
                    .HasForeignKey(x => x.PlantId);

                model.Entity<ProductInPlant>()
                    .HasOne(x => x.Product)
                    .WithMany()
                    .HasForeignKey(x => x.ProductId);
        }
    }
}
