using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidade
{
    public enum TaxGroupType 
    {
        [Description("Não Credenciado")]
        N_CRED,

        [Description("Credenciado")]
        CRED
    }
}
