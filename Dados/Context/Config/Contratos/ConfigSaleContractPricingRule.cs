using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigSaleContractPricingRule
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<SaleContractPricingRule>(t =>
            {
                t.ToTable("TB_CONT_VENDA_REGRA_PRECO");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_REGRA_PRECO").UseOracleIdentityColumn();
                t.Property(p => p.ParentRuleId).HasColumnName("CD_SEQ_REGRA_PAI");
                t.Property(p => p.Name).HasColumnName("NM_NOME");                
                t.Property(p => p.FlatPrice).HasColumnName("VL_PRECO_FIXO");                
                t.Property(p => p.EsalqDescription).HasColumnName("CD_DESCRICAO_ESALQ");
                t.Property(p => p.IsEsalqCurrent).HasColumnName("ST_ESALQ_CORRENTE");
                t.Property(p => p.NetDiscount).HasColumnName("VL_DESCONTO_LIQUIDO");
                t.Property(p => p.NetDiscountPercent).HasColumnName("VL_DESCONTO_LIQ_PERCENTUAL");
                t.Property(p => p.IsCumulativeNetDiscount).HasColumnName("ST_DESCONTO_LIQ_CUMULATIVO");
                t.Property(p => p.GrossDiscount).HasColumnName("VL_DESCONTO_BRUTO");
                t.Property(p => p.GrossDiscount).HasColumnName("VL_DESCONTO_BRUTO_PERCENTUAL");
                t.Property(p => p.IsCumulativeGrossDiscount).HasColumnName("ST_DESCONTO_BRUTO_CUMULATIVO");
                t.Property(p => p.Rebate).HasColumnName("VL_REBATE");
                t.Property(p => p.IsRebateWithinTaxes).HasColumnName("ST_REBATE_DENTRO_IMPOSTO");
                t.Property(p => p.Details).HasColumnName("DS_DETALHES");
                t.Property(p => p.IsWeeklyAverage).HasColumnName("ST_MEDIA_SEMANAL");               

                t.Property(p => p.EsalqType).HasColumnName("VL_TIPO_ESALQ")
                                    .HasConversion(ColumnConverter.EsalqTypeConverter());
                t.Property(p => p.PrecoPBPeriodType).HasColumnName("VL_PRECO_PB_PERIODO")
                                    .HasConversion(ColumnConverter.PrecoPBPeriodTypeConverter());           
                t.Property(p => p.PricingType).HasColumnName("VL_TIPO_PRECIFICACAO")
                                    .HasConversion(ColumnConverter.PricingTypeConverter());
                t.Property(p => p.EsalqPeriodType).HasColumnName("VL_PERIODICIDADE_ESALQ")
                                    .HasConversion(ColumnConverter.PeriodTypeConverter());
                t.Property(p => p.AdjustReferenceType).HasColumnName("VL_ESALQ_REFERENCIA_AJUSTE")
                                    .HasConversion(ColumnConverter.PricingAdjustReferenceTypeConverter());
                t.Property(p => p.DiflogIncidenceType).HasColumnName("VL_INCIDENCIA_DIFLOG")
                                    .HasConversion(ColumnConverter.PricingIncidenceTypeConverter());
                t.Property(p => p.FreightIncidenceType).HasColumnName("VL_INCIDENCIA_FRETE")
                                    .HasConversion(ColumnConverter.PricingIncidenceTypeConverter());
           
                t.Property(p => p.PrecoPBModalId).HasColumnName("CD_PRECO_PB_MODAL");
                t.HasOne(b => b.PrecoPBModal)
                    .WithMany()
                    .HasForeignKey(b => b.PrecoPBModalId);

                t.Property(p => p.PrecoPBDescriptionId).HasColumnName("CD_PRECO_PB_DESCRIPTION");
                t.HasOne(b => b.PrecoPBDescription)
                    .WithMany()
                    .HasForeignKey(b => b.PrecoPBDescriptionId);

                t.Property(p => p.PrecoPBProductId).HasColumnName("CD_PRECO_PB_PRODUTO");
                t.HasOne(b => b.PrecoPBProduct)
                    .WithMany()
                    .HasForeignKey(b => b.PrecoPBProductId);
                
            });

            
        }
    }
}
