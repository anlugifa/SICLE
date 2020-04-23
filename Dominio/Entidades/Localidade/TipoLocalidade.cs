using System;
using System.ComponentModel;

namespace Dominio.Entidades.Localidades
{
    public enum TipoLocalidade 
    {
        [Description("Região")]
        R = 'R',

        [Description("Usinas")]
		U = 'U',

        [Description("Terminal")]
		T = 'T',

        [Description("Client")]
		C = 'C'
    }
}
