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

        public void AlterContract(SaleContract contract)
        {
            // cria o ApprovalSaleContract com base no contrato do banco

            // atribui os campos do Contrato DTO que veio da Tela (no parâmetro)

            // atribui o mestre.

            //Se contrato está com status CREATED_IN_APPROVAL, cria o contrato como Evaludated

            // Se não, 
            // Puxa todos os Approval associados 
            // 

        }

    }
}