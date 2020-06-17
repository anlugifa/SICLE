using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Contrato
{
    public class EvaluatedSaleContract : SaleContract
    {
        public long? ContractInApprovalId { get; set; }
        public ApprovalSaleContract ContractInApproval { get; set; } = null!;
    }
}
