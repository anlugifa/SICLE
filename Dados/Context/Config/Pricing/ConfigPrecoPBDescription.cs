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
    public class ConfigPrecoPBDescription
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<PrecoPBDescription>(t =>
            {
                t.ToTable("TB_PRECO_PB_POLO");
                t.HasKey(p => p.Id);

                // generator: SEQ_PRECO_PB_DESCRIPTION
                t.Property(p => p.Id).HasColumnName("CD_PRECO_PB_DESCRIPTION").UseOracleIdentityColumn();
                t.Property(p => p.Value).HasColumnName("DS_PRECO_PB_POLO");              
            });
        }
    }
}
