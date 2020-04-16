
using System;
using System.ComponentModel;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    public enum ContractStatus
    {
        [Description("Alterado")]
        MODIFIED,
        
        [Description("Novo em Aprovação")]
        CREATED_IN_APPROVAL,
        
        [Description("Alterado em Aprovação")]
        MODIFIED_IN_APPROVAL,
        
        [Description("Aprovado")]
        APPROVED,

        [Description("Rejeitado")]
        REJECTED,

        [Description("Removido")]
        REMOVED
    }
}