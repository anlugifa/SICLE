using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigMapPricingRule_VolumePeriod
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<MapPricingRule_PricingPeriod>(t =>
            {
                t.ToTable("TB_CONT_VENDA_PERIODO_REGRA");
                t.HasKey(p => new { p.PricingRuleId, p.PricingPeriodId});

                t.Property(p => p.PricingRuleId).HasColumnName("CD_SEQ_REGRA_PRECO");
                t.Property(p => p.PricingPeriodId).HasColumnName("CD_SEQ_PERIODO_PRECO");        

                t.HasOne(p => p.SaleContractPricingRule)
                    .WithMany()
                    .HasForeignKey(p => p.PricingRuleId);      
                    
                t.HasOne(p => p.SaleContractPricingPeriod)
                    .WithMany(p => p.MapPricingRules)
                    .HasForeignKey(p => p.PricingPeriodId);
            });
        }
    }
}
