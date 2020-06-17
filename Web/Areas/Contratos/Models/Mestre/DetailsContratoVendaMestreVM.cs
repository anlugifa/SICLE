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
using Sicle.Business.Contratos;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class DetailsContratoVendaMestreVM : PaginatedList<SaleContract>
    {
        public long ContratoMestreId { get; set; }
        public MasterSaleContract ContratoMeste { get; set; }

        public IEnumerable<SelectListItem> ListStatus
        {
            get
            {
                return EnumHelper.GetSelectList<ContractStatus>();
            }
        }        

        public DetailsContratoVendaMestreVM(MasterSaleContract contrato, List<SaleContract> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
            this.ContratoMeste = contrato;
            this.ContratoMestreId = contrato.Id;
        }

        public static async Task<DetailsContratoVendaMestreVM> 
                CreateAsync(MasterSaleContract contrato, IQueryable<SaleContract> source, int pageIndex)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * _pageSize).Take(_pageSize).ToListAsync();
            return new DetailsContratoVendaMestreVM(contrato, items, count, pageIndex, _pageSize);
        }

        public ContratoVendaRow ConvertoToViewModel(SaleContract model)
        {
            return new ContratoVendaRow(model);
        }        

        public String GetTotalVolume()
        {
            return new MasterSaleContractBus().GetTotalVolume(ContratoMeste).ToStr();
        }
    }
}
