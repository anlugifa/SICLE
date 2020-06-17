using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Contratos
{
    public class ConfigEvaluatedContract
    {
        internal static void Config(ModelBuilder model)
        {            
            model.Entity<EvaluatedSaleContract>(t =>
            {                
                t.ToTable("TB_CONTRATOS_VENDA")
                    .HasBaseType(typeof(SaleContract));         

                t.Property(p => p.ContractInApprovalId).HasColumnName("CD_CONTRATO_EM_APROVACAO");                
            });

            model.Entity<EvaluatedSaleContract>()
                .HasOne(x => x.ContractInApproval)
                .WithMany()
                .HasForeignKey(x => x.ContractInApprovalId);                
        }
    }
}
