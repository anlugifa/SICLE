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
    public class ConfigPrecoPBModal
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<PrecoPBModal>(t =>
            {
                t.ToTable("TB_PRECO_PB_MODAL");
                t.HasKey(p => p.Id);

                // generator: SEQ_PRECO_PB_MODAL
                t.Property(p => p.Id).HasColumnName("CD_PRECO_PB_MODAL").UseOracleIdentityColumn();
                t.Property(p => p.Name).HasColumnName("DS_PRECO_PB_MODAL");              
            });
        }
    }
}
