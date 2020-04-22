using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum CGCType
    {
        [Description("Cliente")]
        CLIENT,

        [Description("Grupo de Clientes")]
	    GROUP
    }
}