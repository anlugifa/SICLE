using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Localidades
{
    public class ConfigCompany
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Company>(t =>
            {
                t.ToTable("TB_EMPRESAS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_EMPRESAS");
                t.Property(p => p.Name).HasColumnName("NM_EMPRESAS");
                t.Property(p => p.CodeSys).HasColumnName("CD_EXPORTSYS");
                t.Property(p => p.CodeSap).HasColumnName("CD_SAP");
                t.Property(p => p.SAPEnv).HasColumnName("DS_AMBIENTE_SAP");
            });
        }
    }
}
