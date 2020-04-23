using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidades
{
    public enum StatusLocalidade 
    {
        [Description("Ativo")]
        ACTIVE,

        [Description("Desativado")]
        INACTIVE
    }
}
