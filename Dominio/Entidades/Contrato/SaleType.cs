using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum SaleType
    {
        [Description("CIF")]
        CIF,

        [Description("PVU")]
	    EXW,

        [Description("FOB")]
        FOB,

        [Description("CFR")]
        CFR,

        [Description("FCA")]
        FCA,

        [Description("NON")]
        NON
    }
}