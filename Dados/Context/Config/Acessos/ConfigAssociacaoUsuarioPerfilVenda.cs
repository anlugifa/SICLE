using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Acessos
{
    internal class ConfigAssociacaoUsuarioPerfilVenda
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<AssociacaoUsuarioPerfilVenda>(t =>
            {
                t.ToTable("TB_USUARIOS_PERFIS_VENDA");
                t.HasKey(o => new { o.UsuarioId, o.PerfilVendaId });
                t.Property(p => p.UsuarioId).HasColumnName("CD_SEQ_USUARIO");
                t.Property(p => p.PerfilVendaId).HasColumnName("CD_SEQ_PERFIL");
            });

            model.Entity<AssociacaoUsuarioPerfilVenda>()
                        .HasOne(b => b.Usuario)
                        .WithMany(b => b.PerfilVendas)
                        .HasForeignKey(b => b.UsuarioId);

            model.Entity<AssociacaoUsuarioPerfilVenda>()
                        .HasOne(b => b.PerfilVenda)
                        .WithMany(b => b.Usuarios)
                        .HasForeignKey(b => b.PerfilVendaId);
        }  
    }
}
