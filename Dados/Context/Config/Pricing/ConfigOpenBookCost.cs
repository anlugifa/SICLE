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
                t.Property(p => p.II).HasColumnName("VL_II");
                t.Property(p => p.IIBl).HasColumnName("VL_II_BL");
                t.Property(p => p.Ipi).HasColumnName("VL_IPI");
                t.Property(p => p.IpiBl).HasColumnName("VL_IPI_BL");
                t.Property(p => p.Cide).HasColumnName("VL_CIDE");
                t.Property(p => p.CideBl).HasColumnName("VL_CIDE_BL");
                t.Property(p => p.MultaCide).HasColumnName("VL_MULTA_CIDE");
                t.Property(p => p.MultaCideBl).HasColumnName("VL_MULTA_CIDE_BL");
                t.Property(p => p.JurosCide).HasColumnName("VL_JUROS_CIDE");
                t.Property(p => p.JurosCideBl).HasColumnName("VL_JUROS_CIDE_BL");
                t.Property(p => p.Pis).HasColumnName("VL_PIS");
                t.Property(p => p.PisBl).HasColumnName("VL_PIS_BL");
                t.Property(p => p.MultaPis).HasColumnName("VL_MULTA_PIS");
                t.Property(p => p.MultaPisBl).HasColumnName("VL_MULTA_PIS_BL");
                t.Property(p => p.JurosPis).HasColumnName("VL_JUROS_PIS");
                t.Property(p => p.JurosPisBl).HasColumnName("VL_JUROS_PIS_BL");
                t.Property(p => p.Cofins).HasColumnName("VL_COFINS");
                t.Property(p => p.CofinsBl).HasColumnName("VL_COFINS_BL");
                t.Property(p => p.MultaCofins).HasColumnName("VL_MULTA_COFINS");
                t.Property(p => p.JurosCofins).HasColumnName("VL_JUROS_COFINS");
                t.Property(p => p.JurosCofinsBl).HasColumnName("VL_JUROS_COFINS_BL");
                t.Property(p => p.IcmsProp).HasColumnName("VL_ICMS_PROP");
                t.Property(p => p.IcmsPropBl).HasColumnName("VL_ICMS_PROP_BL");
                t.Property(p => p.IcmsST).HasColumnName("VL_ICMSST");
                t.Property(p => p.IcmsSTBl).HasColumnName("VL_ICMSST_BL");
                t.Property(p => p.TaxIcms).HasColumnName("VL_TAX_ICMS");
                t.Property(p => p.TaxIcmsBl).HasColumnName("VL_TAX_ICMS_BL");
                t.Property(p => p.TaxST).HasColumnName("VL_TAXST");
                t.Property(p => p.TaxSTBl).HasColumnName("VL_TAXST_BL");
                t.Property(p => p.Despachante).HasColumnName("VL_DESPACHANTE");
                t.Property(p => p.DespachanteBl).HasColumnName("VL_DESPACHANTE_BL");
                t.Property(p => p.Descarga).HasColumnName("VL_DESCARGA");
                t.Property(p => p.DescargaBl).HasColumnName("VL_DESCARGA_BL");
                t.Property(p => p.Aduaneiro).HasColumnName("VL_ADUANEIRO");
                t.Property(p => p.AduaneiroBl).HasColumnName("VL_ADUANEIRO_BL");
                t.Property(p => p.Di).HasColumnName("VL_DI");
                t.Property(p => p.DiBl).HasColumnName("VL_DI_BL");
                t.Property(p => p.IOF).HasColumnName("VL_IOF");
                t.Property(p => p.IOFBl).HasColumnName("VL_IOF");
                t.Property(p => p.HonDespachante).HasColumnName("VL_HON_DESPACHANTE");
                t.Property(p => p.HonInspetor).HasColumnName("VL_HON_INSPETOR");
                t.Property(p => p.Sgs).HasColumnName("VL_HON_INSPETOR");
                t.Property(p => p.TaxLiber).HasColumnName("VL_TAX_LIBER");
                t.Property(p => p.SisComex).HasColumnName("VL_SISCOMEX");
                t.Property(p => p.Liber).HasColumnName("VL_LIBER");
                t.Property(p => p.Armazenagem).HasColumnName("VL_ARMAZENAGEM");               
                t.Property(p => p.ChangeDate).HasColumnName("DT_DATA");

                t.Property(p => p.UserId).HasColumnName("CD_USER");
                t.HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId);

                t.Property(p => p.PricingRuleId).HasColumnName("CD_REGRA_PRECO");
                t.HasOne(b => b.PricingRule)
                    .WithMany()
                    .HasForeignKey(b => b.PricingRuleId);
                
            });
        }
    }
}
