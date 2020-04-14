using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Acessos
{
    public class ConfigUsuario
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<Usuario>(t =>
            {
                t.ToTable("TB_USUARIOS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_USUARIO");
                t.Property(p => p.Matricula).HasColumnName("DS_LOGIN");
                t.Property(p => p.Nome).HasColumnName("NM_USUARIO");
                t.Property(p => p.NomeSGP).HasColumnName("NM_USUARIO_SGP");
                t.Property(p => p.Email).HasColumnName("DS_EMAIL");
                t.Property(p => p.IsScaPerfil).HasColumnName("TP_PERFIL");
                t.Property(p => p.IsAtivo).HasColumnName("ST_ATIVO");
                t.Property(p => p.IsTraderComb).HasColumnName("DS_TRADER_COMBUSTIVEL");
                t.Property(p => p.IsTraderEAB).HasColumnName("DS_TRADER_ENERGIA");

            });
        }
    }
}
