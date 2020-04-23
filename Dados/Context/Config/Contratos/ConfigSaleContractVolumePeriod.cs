using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigSaleContractVolumePeriod
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<SaleContractVolumePeriod>(t =>
            {
                t.ToTable("TB_CONT_VEND_VOLUME_PERIOD");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_VOLUME_PERIODO").UseOracleIdentityColumn();
                t.Property(p => p.Volume).HasColumnName("VL_VOLUME");
                t.Property(p => p.Year).HasColumnName("NR_ANO");
                t.Property(p => p.Month).HasColumnName("NR_MES");
                t.Property(p => p.Week).HasColumnName("NR_SEMANA");
                t.Property(p => p.SaleQuotaId).HasColumnName("CD_SEQ_PERIODO_VOLUME");
            });

            model.Entity<SaleContractVolumePeriod>()
                        .HasOne(b => b.SaleQuota)
                        .WithMany(b => b.VolumePeriods)
                        .HasForeignKey(b => b.SaleQuotaId);
        }
    }
}
