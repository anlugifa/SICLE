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
    public class ContratoVendaMestreBus : SicleBusiness<ContratoVendaMestre>
    {
        public async Task<List<ContratoVenda>> GetByMaster(long masterId, int pageIndex, int pageSize)
        {
            using (var repo = new BaseRepository<ContratoVenda>())
            {
                var q = repo.AsQueryable()
                            .Where(x => x.ContratoMestreId == masterId)
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

                return await q;
            }
        }

        public override ContratoVendaMestre MergeFromDB(ContratoVendaMestre localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: ContratoVendaMestre");

            objFromDB.Nickname = localCopy.Nickname;
            objFromDB.Discriminator = localCopy.Discriminator;
            objFromDB.Observation = localCopy.Observation;
            objFromDB.IsActive = localCopy.IsActive;

            return objFromDB;
        }
    }
}