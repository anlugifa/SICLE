using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config
{
    internal class ConfigAssociacaoGrupoUsuario
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<AssociacaoGrupoUsuario>(t =>
            {
                t.ToTable("TB_USUARIOS_GRUPOS");
                t.HasKey(o => new { o.UsuarioId, o.GrupoUsuarioId });
                t.Property(p => p.UsuarioId).HasColumnName("CD_SEQ_USUARIO");
                t.Property(p => p.GrupoUsuarioId).HasColumnName("CD_SEQ_GRUPOUSUARIO");
            });

            model.Entity<AssociacaoGrupoUsuario>()
                        .HasOne(b => b.Usuario)
                        .WithMany(b => b.Grupos)
                        .HasForeignKey(b => b.UsuarioId);

            model.Entity<AssociacaoGrupoUsuario>()
                        .HasOne(b => b.Grupo)
                        .WithMany(b => b.Usuarios)
                        .HasForeignKey(b => b.GrupoUsuarioId);
        }
    }
}
