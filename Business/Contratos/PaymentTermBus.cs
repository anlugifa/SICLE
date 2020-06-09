using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;

namespace Sicle.Business.Contratos
{
    public class PaymentTermBus : SicleBusiness<PaymentTerm>
    {
        public override PaymentTerm MergeFromDB(PaymentTerm localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: PaymentTerm");


            objFromDB.Code = localCopy.Code;
            objFromDB.PaymentTermType = localCopy.PaymentTermType;       
            objFromDB.Env = localCopy.Env;
            objFromDB.Days = localCopy.Days;        

            objFromDB.Description = localCopy.Description;
            objFromDB.IsFixDate = localCopy.IsFixDate;       
            objFromDB.IsActive = localCopy.IsActive;            
            
            return objFromDB;
        }
    }
}