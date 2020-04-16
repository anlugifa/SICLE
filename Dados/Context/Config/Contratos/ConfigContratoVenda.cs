using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigContratoVenda
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<ContratoVenda>(t =>
            {
                t.ToTable("TB_CONTRATOS_VENDA");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_CONTRATO").UseOracleIdentityColumn();
                t.Property(p => p.Nickname).HasColumnName("DS_APELIDO");
                t.Property(p => p.Name).HasColumnName("NM_CONTRATO");
                t.Property(p => p.Begin).HasColumnName("DT_INICIO");
                t.Property(p => p.End).HasColumnName("DT_FIM");
                t.Property(p => p.Flexibility).HasColumnName("VL_FLEXIBILIDADE");
                t.Property(p => p.TotalVolume).HasColumnName("VL_VOLUME_TOTAL");
                t.Property(p => p.EconomicGroup).HasColumnName("DS_GRUPO_ECONOMICO");
                t.Property(p => p.IsAvailableForBroker).HasColumnName("ST_DISP_BROKER");
                t.Property(p => p.Observation).HasColumnName("DS_OBSERVACAO");
                t.Property(p => p.IsActive).HasColumnName("DS_ATIVO");
                t.Property(p => p.IsDeleted).HasColumnName("DS_DELETADO");
                t.Property(p => p.Safra).HasColumnName("CD_SAFRA");
                t.Property(p => p.Reason).HasColumnName("DS_JUSTIFICATIVA");
                t.Property(p => p.CreationDate).HasColumnName("DT_CRIACAO");

                t.Property(p => p.DateOfApproval).HasColumnName("DS_DATA_APROVACAO");
                t.Property(p => p.Approver).HasColumnName("NM_APROVADOR");
                t.Property(p => p.DateOfTradingApproval).HasColumnName("DS_DATA_APROVACAO_TRADING");
                t.Property(p => p.TradingApprover).HasColumnName("DS_DATA_APROVACAO_TRADING");
                t.Property(p => p.DateOfFinancesApproval).HasColumnName("DS_DATA_APROVACAO_FINANCAS");
                t.Property(p => p.FinancesApprover).HasColumnName("NM_APROVADOR_FINANCAS");
                t.Property(p => p.ContractVersion).HasColumnName("VL_VERSAO");
                t.Property(p => p.HasForecast).HasColumnName("ST_FORECAST");
                t.Property(p => p.MaxForecast).HasColumnName("VL_MAX_FORECAST");

                t.Property(p => p.HasNegotiationBC).HasColumnName("DS_NEGOTIATION_BC");
                t.Property(p => p.IsOperacaoNNE).HasColumnName("DS_OPERACAO_NNE");

                t.Property(p => p.CreationUserId).HasColumnName("CD_USUARIO_CRIACAO");
                t.Property(p => p.EditorId).HasColumnName("CD_USUARIO_EDICAO");
                t.Property(p => p.TraderId).HasColumnName("CD_SEQ_TRADER");
                t.Property(p => p.BrokerId).HasColumnName("CD_SEQ_BROKER");

                t.Property(p => p.ProductGroupId).HasColumnName("CD_SEQ_GRUPOPRODUTO");
                t.Property(p => p.ClientGroupId).HasColumnName("CD_SEQ_GRUPO_CLIENTE");
                t.Property(p => p.PaymentTermId).HasColumnName("CD_SEQ_CONDICAO_PAGAMENTO");

                t.Property(p => p.ContratoMestreId).HasColumnName("CD_SEQ_CONTRATO_MESTRE");
            });

            model.Entity<ContratoVenda>()
                        .HasOne(b => b.CreationUser)
                        .WithMany()
                        .HasForeignKey(f => f.CreationUserId);

            model.Entity<ContratoVenda>()
                        .HasOne(b => b.Editor)
                        .WithMany()
                        .HasForeignKey(f => f.EditorId);

            model.Entity<ContratoVenda>()
                    .HasOne(b => b.Trader)
                    .WithMany()
                    .HasForeignKey(f => f.TraderId);

            model.Entity<ContratoVenda>()
                        .HasOne(b => b.Broker)
                        .WithMany()
                        .HasForeignKey(f => f.BrokerId);

            model.Entity<ContratoVenda>()
                        .HasOne(b => b.ProductGroup)
                        .WithMany()
                        .HasForeignKey(f => f.ProductGroupId);       

            model.Entity<ContratoVenda>()
                        .HasOne(b => b.ClientGroup)
                        .WithMany()
                        .HasForeignKey(f => f.ClientGroupId);                  

            model.Entity<ContratoVenda>()
                        .HasOne(b => b.ContratoMestre)
                        .WithMany(b => b.Contratos)
                        .HasForeignKey(f => f.ContratoMestreId);

        }
    }
}
