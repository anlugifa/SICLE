using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados.Repository.Base;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository
{
    public class SaleContractQuotaRepositoy : BaseRepository<SaleContractQuota, long>
    {
        public SaleContractQuotaRepositoy(ApplicationDBContext context) : base(context)
        {
        }

        public override SaleContractQuota Get(long id)
        {
            return _context.SaleContractQuotas.First(o => o.Id == id);
        }

        public override long GetPkValue(SaleContractQuota entity)
        {
            return (long)typeof(SaleContractQuota).GetProperty("Id").GetValue(entity);
        }        
    }
}