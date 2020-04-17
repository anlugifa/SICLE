using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Localidades
{
    public class ConfigRestricaoCargaDescarga
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<RestricaoCargaDescarga>(t =>
            {
                t.ToTable("TB_RESTRICOES_CARGA_DESCARGA");
                t.HasKey(x => new { x.PlantId, x.TipoRestricao });
                
                t.Property(p => p.PlantId).HasColumnName("CD_SEQ_LOCALIDADE");
                t.Property(p => p.TipoRestricao).HasColumnName("TP_RESTRICAO");
                t.Property(p => p.Capacity).HasColumnName("QT_CAPACIDADE");
            });
        }
    }
}
