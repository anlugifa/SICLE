using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum MailStatus
    {
        [Description("")]
        NONE,

        [Description("Aguardando")]
	    NOT_SENT,

        [Description("Erro")]
        ERROR,

        [Description("Enviado")]
        SENT
    }
}