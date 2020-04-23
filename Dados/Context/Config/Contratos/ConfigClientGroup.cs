using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigClientGroup
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<ClientGroup>(t =>
            {
                t.ToTable("TB_GRUPOS_CLIENTES");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_GRUPO_CLIENTE");
                t.Property(p => p.Code).HasColumnName("CD_GRUPO_CLIENTE");

                t.Property(p => p.Type)
                                    .HasColumnName("TP_GRUPO_CLIENTE")
                                    .HasConversion(ColumnConverter.ClientGroupTypeConverter());

                t.Property(p => p.Description).HasColumnName("DS_GRUPO_CLIENTE");
                t.Property(p => p.Email).HasColumnName("NM_EMAIL");
            });

            model.Entity<ClientGroup>()
                       .HasMany(b => b.Clientes)
                       .WithOne(b => b.ClientGroup)
                       .HasForeignKey(b => b.ClientGroupId);
        }
    }
}
