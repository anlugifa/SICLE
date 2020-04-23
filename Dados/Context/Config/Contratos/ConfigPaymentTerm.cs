using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigPaymentTerm
    {
        internal static void Config(ModelBuilder model)
        {           
            model.Entity<PaymentTerm>(t =>
            {
                t.ToTable("TB_CONDICOES_PAGAMENTO");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_CONDICAO_PAGAMENTO");
                t.Property(p => p.Code).HasColumnName("CD_CONDICAO");   

                t.Property(p => p.PaymentTermType)
                        .HasColumnName("TP_COMPRA_VENDA")
                        .HasConversion(ColumnConverter.PaymentTermTypeConverter());

                t.Property(p => p.Env)
                        .HasColumnName("CD_ENV")
                        .HasConversion(ColumnConverter.SAPEnvTypeConverter());

                t.Property(p => p.Days).HasColumnName("QT_PRAZO_MEDIO"); 
                t.Property(p => p.Description).HasColumnName("DS_CONDICAO_PAGAMENTO"); 

                t.Property(p => p.IsFixDate)
                                .HasColumnName("VL_DATA_FIXA")
                                .HasConversion(ColumnConverter.BooToCharConverter());

                t.Property(p => p.IsActive).HasColumnName("ST_ATIVO");
            });
        }
    }
}
