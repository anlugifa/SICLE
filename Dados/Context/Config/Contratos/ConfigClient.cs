using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigClient
    {
        internal static void Config(ModelBuilder model)
        {            
            model.Entity<Client>(t =>
            {                
                t.ToTable("TB_LOCALIDADES")
                    .HasBaseType(typeof(LocalidadeGeografica));         

                t.Property(p => p.Email).HasColumnName("DS_EMAIL");
                t.Property(p => p.UndoingEmail).HasColumnName("DS_EMAIL_DESFAZIMENTO");
                t.Property(p => p.IE).HasColumnName("NR_IE");
                t.Property(p => p.CNPJ).HasColumnName("NR_CNPJ");
                t.Property(p => p.Operation).HasColumnName("DS_OPERACAO");
                t.Property(p => p.CreditLimit).HasColumnName("VL_LIMITE_CREDITO");
                t.Property(p => p.CreditDisp).HasColumnName("VL_CREDITO_DISPONIVEL");
                t.Property(p => p.DataUltimaCompra).HasColumnName("DT_ULTIMA_COMPRA");
                t.Property(p => p.Hierarchy1).HasColumnName("DS_HIERARQUIA_1");
                t.Property(p => p.Hierarchy2).HasColumnName("DS_HIERARQUIA_2");
                t.Property(p => p.Hierarchy3).HasColumnName("DS_HIERARQUIA_3");
                t.Property(p => p.Rating).HasColumnName("DS_RATING_FINANCEIRO");       
                t.Property(p => p.IsBlockade).HasColumnName("ST_BLOQUEIO");
                t.Property(p => p.IsArmazenagem).HasColumnName("ST_ARMAZENAGEM");                         
                t.Property(p => p.IsScaProfile).HasColumnName("ST_PERFIL_SCA");                

                t.Property(p => p.Type)
                            .HasColumnName("DS_TIPO")
                            .HasConversion(ColumnConverter.ClientTypeConverter());

                t.Property(p => p.ClientGroupId).HasColumnName("CD_SEQ_GRUPO_CLIENTE");
                t.Property(p => p.OperatorId).HasColumnName("CD_OPERADOR");
            });

            model.Entity<Client>()
                .HasOne(x => x.ClientGroup)
                .WithMany(x => x.Clientes)
                .HasForeignKey(x => x.ClientGroupId);

            model.Entity<Client>()
                .HasOne(x => x.Operator)
                .WithMany()
                .HasForeignKey(x => x.OperatorId);
                
        }
    }
}
