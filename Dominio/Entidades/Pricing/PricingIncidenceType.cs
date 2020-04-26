using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Pricing
{
    public enum PricingIncidenceType
    {
        [Description("Preço Líquido")]
        PRECO_LIQUIDO,

        [Description("Preço Bruto")]
	    PRECO_BRUTO
    }
}