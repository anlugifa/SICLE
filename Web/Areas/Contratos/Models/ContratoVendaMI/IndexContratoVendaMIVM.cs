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
using Dominio.Entidades.Produtos;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class IndexContratoVendaMIVM : PaginatedList<SaleContract>
    {
        public IndexContratoVendaFilter Filter { get; set; }
        public IEnumerable<ProductGroup> ProductGroups { get; set; }

        public IEnumerable<SelectListItem> ListStatus
        {
            get
            {
                return EnumHelper.GetSelectList<ContractStatus>();
            }
        }

        public IndexContratoVendaMIVM(List<SaleContract> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
        }

        public static new async Task<IndexContratoVendaMIVM> CreateAsync(IQueryable<SaleContract> source, int pageIndex)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * _pageSize).Take(_pageSize).ToListAsync();
            return new IndexContratoVendaMIVM(items, count, pageIndex, _pageSize);
        }

        public ContratoVendaRow ConvertModel(SaleContract contrato)
        {
            return new ContratoVendaRow(contrato);
        }
    }
}
