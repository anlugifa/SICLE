
using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum EndorsementStatus
    {

        [Description("Endossado")]
        ENDORSED,

        [Description("Aguardo do Endosso")]
        IN_ENDORSEMENT,

        [Description("Sem necessidade de endosso")]
        NOT_NECESSARY,

        [Description("Não avaliado")]
        UNVALUED,

        [Description("-")]
        NONE

    }
}