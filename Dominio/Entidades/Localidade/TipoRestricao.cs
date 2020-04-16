using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidade
{
    public enum TipoRestricao 
    {
        [Description("Carga")]
        C,

        [Description("Descarga")]
        R
    }
}