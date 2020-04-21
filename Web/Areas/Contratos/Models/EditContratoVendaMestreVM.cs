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
    public class EditContratoVendaMestreVM : PaginatedList<ContratoVenda>
    {
        public long ContratoMestreId { get; set; }
        public ContratoVendaMestre ContratoMeste { get; set; }

        public IEnumerable<SelectListItem> ListStatus
        {
            get
            {
                return EnumHelper.GetSelectList<ContractStatus>();
            }
        }

        public EditContratoVendaMestreVM(ContratoVendaMestre contrato, List<ContratoVenda> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
            this.ContratoMeste = contrato;
            this.ContratoMestreId = contrato.Id;
        }

        public static async Task<EditContratoVendaMestreVM> 
                CreateAsync(ContratoVendaMestre contrato, IQueryable<ContratoVenda> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new EditContratoVendaMestreVM(contrato, items, count, pageIndex, pageSize);
        }

        public ContratoVendaModel ConvertoToViewModel(ContratoVenda model)
        {
            return new ContratoVendaModel(model);
        }        
    }
}
