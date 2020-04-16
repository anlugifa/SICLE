using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigBroker
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Broker>(t =>
            {
                t.ToTable("TB_BROKER");
                t.HasKey(p => p.Code);

                t.Property(p => p.Code).HasColumnName("CD_BROKER");
                t.Property(p => p.Email).HasColumnName("DS_EMAIL");                
            });
        }
    }
}
