using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigSaleContractQuota
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<SaleContractQuota>(t =>
            {
                t.ToTable("TB_CONTRATO_VENDA_COTA");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_COTA").UseOracleIdentityColumn();
                t.Property(p => p.QuotaVolume).HasColumnName("VL_VOLUME_COTA");
                t.Property(p => p.TotalVolume).HasColumnName("VL_VOLUME_TOTAL");
                t.Property(p => p.Diflog).HasColumnName("VL_DIFLOG");
                t.Property(p => p.Freight).HasColumnName("VL_FREIGHT");               
                
                t.Property(p => p.Type)
                                    .HasColumnName("DS_INCOTERM")
                                    .HasConversion(ColumnConverter.SaleTypeConverter());

                t.Property(p => p.ContratoId).HasColumnName("CD_SEQ_CONTRATO_VENDA");
                t.Property(p => p.OrigemId).HasColumnName("CD_ORIGEM");
                t.Property(p => p.DestinoId).HasColumnName("CD_DESTINO");                
            });


            model.Entity<SaleContractQuota>()
                        .HasOne(b => b.Contrato)
                        .WithMany(b => b.Quotas)
                        .HasForeignKey(b => b.ContratoId);

            model.Entity<SaleContractQuota>()
                        .HasOne<Localidade>(b => b.Origem)
                        .WithMany()
                        .HasForeignKey(b => b.OrigemId);

            model.Entity<SaleContractQuota>()
                        .HasOne<Client>(b => b.Destino)
                        .WithMany()
                        .HasForeignKey(b => b.DestinoId);

            // model.Entity<SaleContractQuota>()
            //             .HasMany(b => b.VolumePeriods)
            //             .WithOne(b => b.SaleQuota)
            //             .HasForeignKey(b => b.SaleQuotaId);        
        }
    }
}
