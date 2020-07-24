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
    public class IndexContratoVendaMIVM<T> : PaginatedList<T> where T: SaleContract
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

        public IndexContratoVendaMIVM(List<T> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
        }

        public static new async Task<IndexContratoVendaMIVM<T>> CreateAsync(IQueryable<T> source, int pageIndex)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * _pageSize).Take(_pageSize).ToListAsync();
            return new IndexContratoVendaMIVM<T>(items, count, pageIndex, _pageSize);
        }

        public static IndexContratoVendaMIVM<T> CreateAsync(IList<T> source, int pageIndex)
        {
            return CreateAsync(source, pageIndex, _pageSize);
        }

        public static IndexContratoVendaMIVM<T> CreateAsync(IList<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new IndexContratoVendaMIVM<T>(items, count, pageIndex, pageSize);
        }
        
        public ContratoVendaRow ConvertModel(SaleContract contrato)
        {
            return new ContratoVendaRow(contrato);
        }
    }
}
