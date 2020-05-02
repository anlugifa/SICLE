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
    public class IndexContratoVendaMestreVM : PaginatedList<ContratoVendaMestre>
    {
        public IEnumerable<SelectListItem> ListStatus {
            get {
                return EnumHelper.GetSelectList<ContractStatus>();
            }
        }

        public IndexContratoVendaMestreVM(List<ContratoVendaMestre> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
        }

        public static new async Task<IndexContratoVendaMestreVM> CreateAsync(IQueryable<ContratoVendaMestre> source, int pageIndex)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * _pageSize).Take(_pageSize).ToListAsync();
            return new IndexContratoVendaMestreVM(items, count, pageIndex, _pageSize);
        }

        public ContratoVendaMestreModel ConvertoToViewModel(ContratoVendaMestre model)
        {
            return new ContratoVendaMestreModel(model);
        }  
    }
}
