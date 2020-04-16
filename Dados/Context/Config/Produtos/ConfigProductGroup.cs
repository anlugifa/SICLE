using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sicle.Dados.Context.Config.Produtos
{
    public class ConfigProductGroup
    {
        internal static void Config(ModelBuilder model)
        {
            model.Entity<ProductGroup>(t =>
            {
                t.ToTable("TB_GRUPOS_PRODUTOS");
                t.HasKey(p => p.Id);

                t.Property(p => p.Id).HasColumnName("CD_SEQ_GRUPOPRODUTO");
                t.Property(p => p.Code).HasColumnName("CD_GRUPOPRODUTO");
                t.Property(p => p.Description).HasColumnName("DS_GRUPOPRODUTO");
                t.Property(p => p.EnglishDescription).HasColumnName("DS_GRUPOPRODUTO_INGLES");
                t.Property(p => p.EsalqType).HasColumnName("TP_ESALQ"); 
                t.Property(p => p.ProductPremium).HasColumnName("VL_PREMIOPRODUTO");
            });
        }
    }
}
