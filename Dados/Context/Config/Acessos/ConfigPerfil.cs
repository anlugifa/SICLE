using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Acessos
{
    public class ConfigPerfil
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Perfil>(t =>
            {
                t.ToTable("TB_PERFIS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_PERFIL");
                t.Property(p => p.Code).HasColumnName("CD_PERFIL");
                t.Property(p => p.Nome).HasColumnName("DS_PERFIL");
                t.Property(p => p.Volume).HasColumnName("VL_VOLUME").HasColumnType("decimal(9, 2)");
                t.Property(p => p.Prazo).HasColumnName("VL_PRAZO").HasColumnType("decimal(38, 0)");
                t.Property(p => p.Preco).HasColumnName("VL_PRECO");
                t.Property(p => p.VolumeContrato).HasColumnName("VL_VOLUME_CONTRATO");
                t.Property(p => p.VolumeComplemento).HasColumnName("VL_VOLUME_COMPLEMENTO");

                t.Property(p => p.VlVolumeEnergia).HasColumnName("VL_VOLUME_CONTRATO_ENERGIA").HasColumnType("decimal(9,2)");
                t.Property(p => p.VlVolumeContratoEnergia).HasColumnName("VL_VOLUME_ENERGIA");
                t.Property(p => p.VlVolumeImportacao).HasColumnName("VL_VOLUME_IMPORTACAO");
                t.Property(p => p.VlPrecoEnergia).HasColumnName("VL_PRECO_ENERGIA");
                t.Property(p => p.VlPrazoEnergia).HasColumnName("VL_PRAZO_ENERGIA").HasColumnType("decimal(10,0)");
                t.Property(p => p.VlVolumeComplementoEnergia).HasColumnName("VL_VOLUME_COMPLEMENTO_ENERGIA");
                t.Property(p => p.VlVolumeMaxPurchaseDerivatives).HasColumnName("VL_VOLUME_DERIVATIVOS");
                t.Property(p => p.VlVolumeMaxOrderDerivatives).HasColumnName("VL_VOLUME_COMPRAS_DERIVATIVOS");
                t.Property(p => p.VlVolumeMaxOrderSubproduct).HasColumnName("VL_VOLUME_SUBPRODUTOS");
                t.Property(p => p.VlVolumeMaxPurchaseSubproduct).HasColumnName("VL_VOLUME_COMPRA_SUBPRODUTOS");
                t.Property(p => p.MaxPeriodImportContract).HasColumnName("VL_MAX_PERIODO_IMPORTACAO").HasColumnType("decimal(10,0)");
                t.Property(p => p.MaxPeriodContract).HasColumnName("VL_MAX_PERIODO_CONTRATO").HasColumnType("decimal(10,0)");
                t.Property(p => p.MaxCreditLimit).HasColumnName("VL_MAX_CREDIT_LIMIT").HasColumnType("decimal(38,0)");

                t.Property(p => p.IsProvisionApprover).HasColumnName("ST_PROVISION_APPROVER");

                t.Property(p => p.ProfileLevel).HasColumnName("TP_NIVEL_PERFIL")
                    .HasConversion(
                        v => v.ToString(),
                        v => (ProfileLevel)Enum.Parse(typeof(ProfileLevel), v));

                t.Property(p => p.Rating).HasColumnName("SG_RATING")
                    .HasConversion(
                        v => v.ToString(),
                        v => (PurchaseRating)Enum.Parse(typeof(PurchaseRating), v));
            });
        }
    }
}
