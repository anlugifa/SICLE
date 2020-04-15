using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Acessos
{
    internal class ConfigPerfilVenda
    {
        internal static void Config(ModelBuilder model)
        {
             model.Entity<PerfilVenda>(t =>
             {
                t.ToTable("TB_PERFIS_VENDA");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_PERFIL");
                t.Property(p => p.Code).HasColumnName("CD_PERFIL");
                t.Property(p => p.Nome).HasColumnName("DS_PERFIL");
                t.Property(p => p.VlVolume).HasColumnName("VL_VOLUME").HasColumnType("decimal(9, 2)");

                t.Property(p => p.VlPrazo).HasColumnName("VL_PRAZO").HasColumnType("decimal(38, 0)");
                t.Property(p => p.VlVolumeContrato).HasColumnName("VL_VOLUME_CONTRATO").HasColumnType("decimal(9, 2)");
                t.Property(p => p.VlVolumeComplemento).HasColumnName("VL_VOLUME_COMPLEMENTO").HasColumnType("decimal(9, 2)");
                t.Property(p => p.VlVolumeMaxOrderDerivatives).HasColumnName("VL_VOLUME_DERIVATIVOS");
                t.Property(p => p.VlVolumeMaxOrderSubproduct).HasColumnName("VL_VOLUME_SUBPRODUTO");
                t.Property(p => p.VlValorComplementoPreco).HasColumnName("VL_VALOR_COMPLEMENTO_PRECO");
                t.Property(p => p.VlVolumeMaxOrderContrato).HasColumnName("VL_VOLUME_ORDEM_CONTRATO").HasColumnType("decimal(9, 2)");
                t.Property(p => p.MaxPeriodSaleForeignContract).HasColumnName("VL_MAX_PERIODO_CONTRATO_ME").HasColumnType("decimal(10, 0)");
                t.Property(p => p.MaxPeriodSaleContract).HasColumnName("VL_MAX_PERIODO_CONTRATO_MI").HasColumnType("decimal(10, 0)");

                t.Property(p => p.IsProvisionApprover).HasColumnName("ST_PROVISION_APPROVER");
                t.Property(p => p.IsForecastApprover).HasColumnName("ST_FORECAST_APPROVER");
                t.Property(p => p.IsYnorFromYcnrApprover).HasColumnName("ST_YNOR_FROM_YCNR_APPROVER");
                t.Property(p => p.IsComplementApprover).HasColumnName("ST_COMPLEMENT_APPROVER");
                t.Property(p => p.IsContractPriceApprover).HasColumnName("ST_CONTRACT_PRICE_APPROVER");
                t.Property(p => p.IsFinanceEndorsement).HasColumnName("ST_ENDOSSO_FINANCAS");

                t.Property(p => p.ProfileLevel).HasColumnName("TP_NIVEL_PERFIL")
                    .HasConversion(
                        v => v.ToString(),
                        v => (ProfileLevel)Enum.Parse(typeof(ProfileLevel), v));
            });
        }
    }
}
