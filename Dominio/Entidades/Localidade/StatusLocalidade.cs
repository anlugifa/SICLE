using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidade
{
    public enum StatusLocalidade 
    {
        [Description("Ativo")]
        ACTIVE,

        [Description("Desativado")]
        INACTIVE
    }
}
