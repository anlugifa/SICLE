using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Localidades;
using Dominio.Entidades.Pricing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Pricing
{
    public class ConfigOpenBookCost
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<OpenBookCost>(t =>
            {
                t.ToTable("TB_OPEN_BOOK");
                t.HasKey(p => p.Id);

                // generator: SEQ_OPEN_BOOK
                //t.Property(p => p.Id).HasColumnName("").UseOracleIdentityColumn();
                t.Property(p => p.Id).HasColumnName("CD_OPEN_BOOK");
                t.Property(p => p.Name).HasColumnName("NM_NOME");
                t.Property(p => p.Quantidade).HasColumnName("VL_QUANTIDADE");
                t.Property(p => p.Afrmm).HasColumnName("VL_ARFMM");
                t.Property(p => p.QuantidadeBl).HasColumnName("VL_QUANTIDADE_BL");
                t.Property(p => p.TaxaFiscalBl).HasColumnName("VL_TAXA_FISCAL_BL");
                t.Property(p => p.AfrmmBl).HasColumnName("VL_ARFMM_BL");
                t.Property(p => p.Demurrage).HasColumnName("VL_DEMURRAGE");
                t.Property(p => p.TotalCost).HasColumnName("VL_TOTAL_COST");
                t.Property(p => p.FilePath).HasColumnName("DS_ARQUIVO");
                t.Property(p => p.FileName).HasColumnName("DS_NOME_ARQUIVO");
                t.Property(p => p.Dap).HasColumnName("VL_DAP");
                t.Property(p => p.DapBl).HasColumnName("VL_DAP_BL");
                t.Property(p => p.Tup).HasColumnName("VL_TUP");
                t.Property(p => p.TupBl).HasColumnName("VL_TUP_BL");
                t.Property(p => p.Sop).HasColumnName("VL_SOP");
                t.Property(p => p.SopBl).HasColumnName("VL_SOP_BL");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
                t.Property(p => p.).HasColumnName("");
            });
        }
    }
}
