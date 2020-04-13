using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Acessos
{
    internal class ConfigGrupoUsuario
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<GrupoUsuario>(t =>
            {
                t.ToTable("TB_GRUPOS_USUARIOS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_GRUPOUSUARIO");
                t.Property(p => p.Code).HasColumnName("CD_GRUPOUSUARIO");
                t.Property(p => p.Nome).HasColumnName("DS_GRUPOUSUARIO");
            });
        }
    }
}
