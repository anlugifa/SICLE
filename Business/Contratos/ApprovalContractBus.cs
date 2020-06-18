using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class ApprovalContractBus : ContratoVendaBus<ApprovalSaleContract>
    {
        public Broker Get(string code)
        {
            using (var repo = new BaseRepository<Broker>())
            {
                return repo.AsQueryable().First(o => o.Code.Equals(code));
            }
        }       

        public override ApprovalSaleContract MergeFromDB(ApprovalSaleContract localCopy)
        {
            var objFromDB = base.MergeFromDB(localCopy);
            objFromDB.EvaluatedContractId = localCopy.EvaluatedContractId;
            
            return objFromDB;
        }
    }
}