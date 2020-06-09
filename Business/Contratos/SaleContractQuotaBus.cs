using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sicle.Business.Contratos
{
    public class SaleContractQuotaBus : SicleBusiness<SaleContractQuota>
    {
        public override SaleContractQuota MergeFromDB(SaleContractQuota localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: SaleContractQuota");
            
            return objFromDB;
        }
    }
}