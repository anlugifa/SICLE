using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados.Repository.Base;
using Dominio.Entidades;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;
using Microsoft.EntityFrameworkCore;

namespace Dados.Repository
{
    public class ProductGroupRepository : BaseRepository<ProductGroup, long>
    {
        public ProductGroupRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override ProductGroup Get(long id)
        {
            return _context.ProductGroups.First(o => o.Id == id);
        }

        public override long GetPkValue(ProductGroup entity)
        {
            return (long)typeof(ProductGroup).GetProperty("Id").GetValue(entity);
        }
    }
}