using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum PeriodType
    {
        [Description("Semanal")]
        SEMANAL,

        [Description("Mensal")]
	    MENSAL
    }
}