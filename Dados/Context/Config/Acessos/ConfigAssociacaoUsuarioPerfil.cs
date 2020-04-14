using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Acessos
{
    internal class ConfigAssociacaoUsuarioPerfil
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<AssociacaoUsuarioPerfil>(t =>
            {
                t.ToTable("TB_USUARIOS_PERFIS");
                t.HasKey(o => new { o.UsuarioId, o.PerfilId });
                t.Property(p => p.UsuarioId).HasColumnName("CD_SEQ_USUARIO");
                t.Property(p => p.PerfilId).HasColumnName("CD_SEQ_PERFIL");
            });

            model.Entity<AssociacaoUsuarioPerfil>()
                        .HasOne(b => b.Usuario)
                        .WithMany(b => b.Perfis)
                        .HasForeignKey(b => b.UsuarioId);

            model.Entity<AssociacaoUsuarioPerfil>()
                        .HasOne(b => b.Perfil)
                        .WithMany(b => b.Usuarios)
                        .HasForeignKey(b => b.PerfilId);
        }
    }
}
