using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidades
{
    public enum TipoRestricao 
    {
        [Description("Carga")]
        C,

        [Description("Descarga")]
        R
    }
}