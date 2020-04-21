using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Util;
using Util;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class IndexContratoVendaMestreModel : PaginatedList<ContratoVendaMestre>
    {
        public IEnumerable<SelectListItem> ListStatus {
            get {
                return EnumHelper.GetSelectList<ContractStatus>();
            }
        }

        public IndexContratoVendaMestreModel(List<ContratoVendaMestre> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
        }

        public static new async Task<IndexContratoVendaMestreModel> CreateAsync(IQueryable<ContratoVendaMestre> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new IndexContratoVendaMestreModel(items, count, pageIndex, pageSize);
        }

        public ContratoVendaMestreModel ConvertoToViewModel(ContratoVendaMestre model)
        {
            return new ContratoVendaMestreModel(model);
        }  
    }
}
