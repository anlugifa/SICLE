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
    public class ConfigPrecoPBProduct
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<PrecoPBProduct>(t =>
            {
                t.ToTable("TB_PRECO_PB_PRODUTO");
                t.HasKey(p => p.Id);

                // generator: SEQ_PRECO_PB_PRODUTO
                t.Property(p => p.Id).HasColumnName("CD_PRECO_PB_PRODUTO").UseOracleIdentityColumn();
                t.Property(p => p.Product).HasColumnName("DS_PRECO_PB_PRODUTO");      
                t.Property(p => p.Address).HasColumnName("DS_PRECO_PB_ENDERECO");      
                t.Property(p => p.Data).HasColumnName("DT_DATA");       
                t.Property(p => p.HaveToImport).HasColumnName("ST_IMPORT");            
            });
        }
    }
}
