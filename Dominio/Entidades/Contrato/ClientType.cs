using System;
using System.ComponentModel;

namespace Dominio.Entidades.Contrato
{
    public enum ClientType
    {
        [Description("Desconhecido")]
        UNKNOWN,

        [Description("Distribuidor")]
        DISTRIBUTOR,

        [Description("Indústria")]
        INDUSTRY
    }
}

