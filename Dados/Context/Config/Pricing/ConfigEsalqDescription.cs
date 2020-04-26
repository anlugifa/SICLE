using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Dominio.Entidades.Pricing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Pricing
{
    public class ConfigEsalqDescription
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<EsalqDescription>(t =>
            {
                t.ToTable("TB_ESALQ_DESCRICAO");
                t.HasKey(p => p.Value);

                // generator: SEQ_PRECO_PB_DESCRIPTION
                //t.Property(p => p.Id).HasColumnName("").UseOracleIdentityColumn();
                t.Property(p => p.Value).HasColumnName("DS_ESALQ_LOCAL");
                t.Property(p => p.Piscofins).HasColumnName("ST_PISCONFINS");              
            });
        }
    }
}
