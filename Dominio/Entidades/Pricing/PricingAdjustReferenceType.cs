using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Pricing
{
    public enum PricingAdjustReferenceType
    {
        [Description("Ordem de Venda")]
        ORDEM_VENDA,

        [Description("Faturamento")]
	    FATURAMENTO
    }
}