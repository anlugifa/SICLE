using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class BrokerBus : SicleBusiness<Broker>
    {
        public Broker Get(string code)
        {
            using (var repo = new BaseRepository<Broker>())
            {
                return repo.AsQueryable().First(o => o.Code.Equals(code));
            }
        }       

        public override Broker MergeFromDB(Broker localCopy)
        {
            var objFromDB = Get(localCopy.Code);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Code +
                    " NOT FOUND FOR ENTITY: Broker");


            objFromDB.Code = localCopy.Code;
            objFromDB.Email = localCopy.Email;            
            
            return objFromDB;
        }
    }
}