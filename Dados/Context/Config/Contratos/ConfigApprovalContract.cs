using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigApprovalContract
    {
        internal static void Config(ModelBuilder model)
        {            
            model.Entity<ApprovalSaleContract>(t =>
            {                
                t.ToTable("TB_CONTRATOS_VENDA")
                    .HasBaseType(typeof(SaleContract));         

                t.Property(p => p.EvaluatedContractId).HasColumnName("CD_CONTRATO_AVALIADO");                
            });

            model.Entity<ApprovalSaleContract>()
                .HasOne(x => x.EvaluatedContract)
                .WithMany()
                .HasForeignKey(x => x.EvaluatedContractId);                
        }
    }
}
