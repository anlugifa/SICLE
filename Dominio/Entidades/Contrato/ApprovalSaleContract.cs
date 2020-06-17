using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Contrato
{
    public class ApprovalSaleContract : SaleContract
    {
        public long? EvaluatedContractId { get; set; }
        public EvaluatedSaleContract EvaluatedContract { get; set; } = null!;

        public ApprovalSaleContract()
        {
            this.InstanceType = "Approval";
        }
    }
}
