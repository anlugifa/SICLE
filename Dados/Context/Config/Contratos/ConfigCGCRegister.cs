﻿using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigCGCRegister
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<CGCRegister>(t =>
            {
                t.ToTable("TB_CADASTRO_CGC");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_CADASTRO_CGC").UseOracleIdentityColumn();
                t.Property(p => p.CGC).HasColumnName("DS_CGC");
                t.Property(p => p.IsActive).HasColumnName("ST_ATIVO");
                
                t.Property(p => p.Type)
                                    .HasColumnName("TP_TIPO")
                                    .HasConversion(ColumnConverter.CGCTypeConverter());

                t.Property(p => p.ClientId).HasColumnName("CD_CLIENTE");
                t.Property(p => p.ClientGroupId).HasColumnName("CD_GRUPO_CLIENTE");                
            });

            model.Entity<CGCRegister>()
                        .HasOne(b => b.Client)
                        .WithMany()
                        .HasForeignKey(b => b.ClientId);

            model.Entity<CGCRegister>()
                        .HasOne(b => b.ClientGroup)
                        .WithMany()
                        .HasForeignKey(b => b.ClientGroupId);
        }
    }
}
