using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sicle.Web.Models;
using Sicle.Web.Util;
using Util;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class IndexContratoVendaMIVM : PaginatedList<ContratoVenda>
    {
        public IEnumerable<SelectListItem> ListStatus {
            get {
                return EnumHelper.GetSelectList<ContractStatus>();
            }
        }

        public IndexContratoVendaMIVM(List<ContratoVenda> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
        }

        public static new async Task<IndexContratoVendaMIVM> CreateAsync(IQueryable<ContratoVenda> source, int pageIndex)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * _pageSize).Take(_pageSize).ToListAsync();
            return new IndexContratoVendaMIVM(items, count, pageIndex, _pageSize);
        }

        public ContratoVendaModel ConvertModel(ContratoVenda contrato)
        {
            return new ContratoVendaModel(contrato);
        } 
    }
}
