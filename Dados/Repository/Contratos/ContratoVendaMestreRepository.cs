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
    public class ContratoVendaMestreRepository : BaseRepository<ContratoVendaMestre, long>
    {
        public ContratoVendaMestreRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override ContratoVendaMestre Get(long id)
        {
            return _context.ContratosVendasMestres.First(o => o.Id == id);
        }

        public override long GetPkValue(ContratoVendaMestre entity)
        {
            return (long)typeof(ContratoVendaMestre).GetProperty("Id").GetValue(entity);
        }
    }
}