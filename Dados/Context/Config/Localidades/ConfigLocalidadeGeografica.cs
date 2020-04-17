using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Localidades
{
    public class ConfigLocalidadeGeografica
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<LocalidadeGeografica>(t =>
            {
                t.ToTable("TP_LOCALIDADE");
                
                t.Property(p => p.Latitude).HasColumnName("VL_LATITUDE");
                t.Property(p => p.Longitude).HasColumnName("VL_LONGITUDE");
                t.Property(p => p.City).HasColumnName("NM_CIDADE");      
                t.Property(p => p.State).HasColumnName("NM_ESTADO");               
                t.Property(p => p.TaxGroupType).HasColumnName("TP_CREDENCIAMENTO"); 
                t.Property(p => p.Status).HasColumnName("DS_STATUS"); 

                t.Property(p => p.IsAgro).HasColumnName("ST_AGROINDUSTRIAL");
                t.Property(p => p.RegionId).HasColumnName("CD_REGIAO"); 
            });
        }
    }
}
