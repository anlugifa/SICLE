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
    public class PaymentTermRepository : BaseRepository<PaymentTerm, long>
    {
        public PaymentTermRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override PaymentTerm Get(long id)
        {
            return _context.PaymentTerms.First(o => o.Id == id);
        }

        public override long GetPkValue(PaymentTerm entity)
        {
            return (long)typeof(PaymentTerm).GetProperty("Id").GetValue(entity);
        }        
    }
}