using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Pricing
{
    public enum PricingType : int
    {
        [Description("Preço Fixo")]
        FLAT = 0,

        [Description("Indexado")]
	    FLOATING = 1,

        [Description("A Mercado")]
        MARKET = 2,

        [Description("OpenBook")]
        OPENBOOK = 3,

        [Description("Preço PB")]
        PRECO_PB = 4
    }
}