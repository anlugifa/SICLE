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
    public class ContratoVendaRepository : BaseRepository<ContratoVenda, long>
    {
        public ContratoVendaRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override ContratoVenda Get(long id)
        {
            return _context.ContratosVendas.First(o => o.Id == id);
        }

        public override long GetPkValue(ContratoVenda entity)
        {
            return (long)typeof(ContratoVenda).GetProperty("Id").GetValue(entity);
        }        
    }
}