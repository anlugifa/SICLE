using System;
using Dados;
using Dados.Repository.Base;
using Dominio.Entidades.Contrato;
using System.Linq;
using Dominio.Entidades.Produtos;

namespace Sicle.Business.Contratos
{
    public class ProductGroupBus : SicleBusiness<ProductGroup>
    {
        public override ProductGroup MergeFromDB(ProductGroup localCopy)
        {
            var objFromDB = Get(localCopy.Id);

            if (objFromDB == null)
                throw new ArgumentException("ERRO: ID " + localCopy.Id +
                    " NOT FOUND FOR ENTITY: ProductGroup");


            objFromDB.Code = localCopy.Code;
            objFromDB.Description = localCopy.Description;
            objFromDB.EnglishDescription = localCopy.EnglishDescription;
            objFromDB.EsalqType = localCopy.EsalqType;
            objFromDB.ProductPremium = localCopy.ProductPremium;

            return objFromDB;
        }
    }
}
