using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class EvaluatedContractBus : ContratoVendaBus<EvaluatedSaleContract>
    {        

        public override EvaluatedSaleContract MergeFromDB(EvaluatedSaleContract localCopy)
        {
            var objFromDB = base.MergeFromDB(localCopy);
            objFromDB.ContractInApprovalId = localCopy.ContractInApprovalId;
            
            return objFromDB;
        }
    }
}