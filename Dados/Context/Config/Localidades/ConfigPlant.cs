using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Localidades
{
    public class ConfigPlant
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Plant>(t =>
            {
                t.ToTable("TB_LOCALIDADES")
                    .HasBaseType(typeof(LocalidadeGeografica));           

                t.Property(p => p.IE).HasColumnName("NR_IE");
                t.Property(p => p.CNPJ).HasColumnName("NR_CNPJ");
                t.Property(p => p.Operation).HasColumnName("DS_OPERACAO");
                t.Property(p => p.FixedCost).HasColumnName("VL_CUSTOFIXO");
                t.Property(p => p.FixedCostZero).HasColumnName("VL_CUSTOFIXOZERO");
                t.Property(p => p.NickName).HasColumnName("DS_APELIDO");
                t.Property(p => p.ShortName).HasColumnName("DS_NOME_ABREVIADO");
                t.Property(p => p.Initials).HasColumnName("DS_SIGLA");
                t.Property(p => p.DefaultObservation).HasColumnName("DS_OBSERVACAO_PADRAO");

                t.Property(p => p.HSun).HasColumnName("QT_DOMINGO1");
                t.Property(p => p.HMon).HasColumnName("QT_SEGUNDA1");
                t.Property(p => p.HTue).HasColumnName("QT_TERCA1");
                t.Property(p => p.HWed).HasColumnName("QT_QUARTA1");
                t.Property(p => p.HThu).HasColumnName("QT_QUINTA1");
                t.Property(p => p.HFri).HasColumnName("QT_SEXTA1");
                t.Property(p => p.HSat).HasColumnName("QT_SABADO1");

                t.Property(p => p.LogistcPrize).HasColumnName("VL_CUSTO_LOGISTICO");
                t.Property(p => p.IsCosan).HasColumnName("TP_PLANTA");
                t.Property(p => p.Ovmi).HasColumnName("NM_OVMI");
                t.Property(p => p.Ovme).HasColumnName("NM_OVME");
                t.Property(p => p.Enterprise).HasColumnName("EMPRESA");
                t.Property(p => p.IsLiter).HasColumnName("VL_LITRO");
                t.Property(p => p.Email).HasColumnName("DS_EMAIL");
                t.Property(p => p.Diflog).HasColumnName("VL_DIFLOG");
                t.Property(p => p.IsPossibleOriginationDestinations).HasColumnName("ST_POSSIBLE_ORIGIN_DESTINATION");
                t.Property(p => p.IsPisCofinsNotApplied).HasColumnName("ST_ISENTO_PIS_COFINS");
                t.Property(p => p.ImportCompanyId).HasColumnName("CD_SEQ_EMPRESA_IMPORTACAO");
                t.Property(p => p.OperatorId).HasColumnName("CD_OPERADOR");
            });

            model.Entity<Plant>()
                    .HasOne<Company>(x => x.ImportCompany)
                    .WithMany()
                    .HasForeignKey(x => x.ImportCompanyId);

            model.Entity<Plant>()
                    .HasOne<ClientGroup>(x => x.Operator)
                    .WithMany()
                    .HasForeignKey(x => x.OperatorId);

            model.Entity<Plant>()
                    .HasMany<RestricaoCargaDescarga>(x => x.LoadUnloadRestriction)
                    .WithOne(x => x.Plant)
                    .HasForeignKey(x => x.PlantId);

            model.Entity<Plant>()
                    .HasMany<ProductInPlant>(x => x.ProductInLocation)
                    .WithOne(x => x.Plant)
                    .HasForeignKey(x => x.PlantId);
        }
    }
}
