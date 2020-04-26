using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Localidades
{
    public class ConfigLocalidades
    {     
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Localidade>(t =>
            {
                t.ToTable("TB_LOCALIDADES");
                t.HasKey(p => p.Id);

                t.HasDiscriminator(x => x.Tipo)                
                    .HasValue<Client>(TipoLocalidade.C)
                    .HasValue<Regiao>(TipoLocalidade.R)
                    .HasValue<Usina>(TipoLocalidade.U)
                    .HasValue<Terminal>(TipoLocalidade.T);
                
                t.Property(p => p.Id).HasColumnName("CD_SEQ_LOCALIDADE");
                t.Property(p => p.Code).HasColumnName("CD_LOCALIDADE");
                t.Property(p => p.Name).HasColumnName("NM_LOCALIDADE");      
                t.Property(p => p.Tipo).HasColumnName("TP_LOCALIDADE")
                        .HasConversion(ColumnConverter.TipoLocalidadeConverter());
            });
        }
    }
}
