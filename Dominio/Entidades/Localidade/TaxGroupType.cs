using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidades
{
    public enum TaxGroupType 
    {
        [Description("Não Credenciado")]
        N_CRED,

        [Description("Credenciado")]
        CRED
    }
}
