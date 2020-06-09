using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class ClientGroupBus : SicleBusiness<ClientGroup>
    {
        public ClientGroup Get(string code)
        {
            using (var repo = new BaseRepository<ClientGroup>())
            {
                return repo.AsQueryable().First(o => o.Code.Equals(code));
            }
        }       

         public override ClientGroup MergeFromDB(ClientGroup localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: ClientGroup");


            objFromDB.Code = localCopy.Code;
            objFromDB.Type = localCopy.Type;       
            objFromDB.Description = localCopy.Description;
            objFromDB.Email = localCopy.Email;            
            
            return objFromDB;
        }
    }
}