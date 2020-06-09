using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class ClientBus : SicleBusiness<Client>
    {
        public Client Get(string cnpj)
        {
            using (var repo = new BaseRepository<Client>())
            {
                return repo.AsQueryable().First(o => o.CNPJ.Equals(cnpj));
            }
        }       

        public override Client MergeFromDB(Client localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: Client");


            objFromDB.Code = localCopy.Code;
            objFromDB.Type = localCopy.Type;       
            objFromDB.UndoingEmail = localCopy.UndoingEmail;
            objFromDB.Email = localCopy.Email;        

            objFromDB.IE = localCopy.IE;
            objFromDB.CNPJ = localCopy.CNPJ;       
            objFromDB.Operation = localCopy.Operation;
            objFromDB.CreditLimit = localCopy.CreditLimit;       
            objFromDB.CreditDisp = localCopy.CreditDisp; 

            objFromDB.Hierarchy1 = localCopy.Hierarchy1;
            objFromDB.Hierarchy2 = localCopy.Hierarchy2;       
            objFromDB.Hierarchy3 = localCopy.Hierarchy3;
            objFromDB.Rating = localCopy.Rating;       
            objFromDB.DataUltimaCompra = localCopy.DataUltimaCompra; 

            objFromDB.IsBlockade = localCopy.IsBlockade;
            objFromDB.IsArmazenagem = localCopy.IsArmazenagem;
            objFromDB.IsScaProfile = localCopy.IsScaProfile;
            objFromDB.ClientGroupId = localCopy.ClientGroupId;
            objFromDB.OperatorId = localCopy.OperatorId;
            
            return objFromDB;
        }
    }
}