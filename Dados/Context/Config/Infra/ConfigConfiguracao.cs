using Dominio.Entidades;
using Dominio.Entidades.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Infra
{
    internal class ConfigConfiguracao
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Configuracao>(t =>
            {
                t.ToTable("TB_CONFIGURACOES");
                t.HasKey(p => p.Code);
                t.Property(p => p.Code).HasColumnName("CD_CONFIGURACAO");
                t.Property(p => p.Value).HasColumnName("VL_CONFIGURACAO");
            });
        }

    }
}
