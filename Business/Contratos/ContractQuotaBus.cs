

using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class ContractQuotaBus : SicleBusiness<SaleContractQuota>
    {
        public Boolean AreEquals(SaleContractQuota obj, SaleContractQuota other)
        {            
            if (obj == null || other == null)
                return false;

            if (obj.OrigemId != other.OrigemId)
                return false;

            if (obj.DestinoId != other.DestinoId)
                return false;

            if (obj.Diflog != other.Diflog)
                return false;

            if (obj.Freight != other.Freight)
                return false;
            
            if (obj.SaleType != other.SaleType)
                return false;

            return true;
        }
    }
}