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

        public async Task<List<ContratoVenda>> GetByMaster(long masterId, int pageIndex, int pageSize)
        {
            var q = _context.ContratosVendas
                         .Where(x => x.ContratoMestreId == masterId)
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();

            return await q;
        }

        public override ContratoVendaMestre MergeFromDB(ContratoVendaMestre localCopy)
        {
            var pkValue = GetPkValue(localCopy);
            var objFromDB = Get(pkValue);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + pkValue +
                    " NOT FOUND FOR ENTITY: CONFIGURACAO");

            objFromDB.Nickname = localCopy.Nickname;
            objFromDB.Discriminator = localCopy.Discriminator;
            objFromDB.Observation = localCopy.Observation;
            objFromDB.IsActive = localCopy.IsActive;

            return objFromDB;
        }
    }
}