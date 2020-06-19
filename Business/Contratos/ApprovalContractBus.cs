using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class ApprovalContractBus : ContratoVendaBus<ApprovalSaleContract>
    {          

        public override ApprovalSaleContract MergeFromDB(ApprovalSaleContract localCopy)
        {
            var objFromDB = base.MergeFromDB(localCopy);
            objFromDB.EvaluatedContractId = localCopy.EvaluatedContractId;
            
            return objFromDB;
        }
    }
}