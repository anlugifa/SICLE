using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigSaleContractPricingPeriod
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<SaleContractPricingPeriod>(t =>
            {
                t.ToTable("TB_CONT_VENDA_PERIODO_PRECO");
                t.HasKey(p => p.Id);

                // SEQ SEQ_CONT_VENDA_PERIODO_PRECO
                t.Property(p => p.Id).HasColumnName("CD_PERIODO_PRECO").UseOracleIdentityColumn();
                t.Property(p => p.Flexibility).HasColumnName("VL_FLEXIBILIDADE");
                t.Property(p => p.Year).HasColumnName("NR_ANO");
                t.Property(p => p.Month).HasColumnName("NR_MES");
                t.Property(p => p.Week).HasColumnName("NR_SEMANA");
                t.Property(p => p.ContratoVendaId).HasColumnName("CD_SEQ_CONTRATO_VENDA");

                t.HasOne(b => b.Contrato)
                    .WithMany(b => b.PricingPeriods)
                    .HasForeignKey(b => b.ContratoVendaId);
            });          
        }
    }
}
