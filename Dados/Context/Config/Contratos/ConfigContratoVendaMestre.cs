﻿using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigContratoVendaMestre
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<ContratoVendaMestre>(t =>
            {
                t.ToTable("TB_CONTRATOS_MESTRES_VENDA");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_CONTRATO_MESTRE");
                t.Property(p => p.IsActive).HasColumnName("DS_ATIVO");    
                t.Property(p => p.Observation).HasColumnName("DS_OBSERVACAO");
                t.Property(p => p.CreationDate).HasColumnName("DT_CRIACAO");
                t.Property(p => p.Nickname).HasColumnName("DS_APELIDO");
                t.Property(p => p.CreationUserId).HasColumnName("CD_USUARIO_CRIACAO");
            });

            model.Entity<ContratoVendaMestre>()
                        .HasOne(b => b.CreationUser)
                        .WithMany(b => b.ContratosMestres)
                        .HasForeignKey(b => b.CreationUserId);

            model.Entity<ContratoVendaMestre>()
                        .HasMany(b => b.Contratos)
                        .WithOne(b => b.ContratoMestre)
                        .HasForeignKey(b => b.ContratoMestreId);
        }
    }
}
