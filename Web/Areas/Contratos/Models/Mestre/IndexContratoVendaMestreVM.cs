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
    public class IndexContratoVendaMestreVM : PaginatedList<ContratoVendaMestre>
    {
        public IndexContratoVendaMestreFilter Filter { get; set; }

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

        public ContratoVendaMestreModel ConvertModel(ContratoVendaMestre model)
        {
            var viewmodel = new ContratoVendaMestreModel(model);

            ConvertModel(model, viewmodel);

            return viewmodel;
        }  

        public void ConvertModel(ContratoVendaMestre mestre, ContratoVendaMestreModel model)
        {
            var buss = new Sicle.Business.Contratos.ContratoMestreVendaBus();
            var status = buss.GetMestreStatus(mestre);

            FinalRowResult(mestre, model, status.Status, status.EndorsementStatus, status.MinDate, status.MaxDate, status.TotalVolume, status.MaxVolume);
        }

        private void FinalRowResult(ContratoVendaMestre mestre,
                    ContratoVendaMestreModel model,
                    ContractStatus? status,
                    EndorsementStatus? endorsementStatus,
                    DateTime? minDate,
                    DateTime? maxDate,
                    double totalVolume,
                    double maxVolume)
        {            
            
            model.Farol = GetFarol(status);
            model.EndorsementIcon = GetEndorsementIcon(endorsementStatus);

            model.Nickname = mestre.Nickname;
            model.StatusMestre = status.HasValue ? status.GetEnumDescription() : "";
            model.EndossoMestre = endorsementStatus.HasValue ? endorsementStatus.GetEnumDescription() : "";
            model.MinDate = minDate.HasValue ? minDate.Value.ToString("dd/mm/yyyy") : String.Empty;
            model.MaxDate = maxDate.HasValue ? maxDate.Value.ToString("dd/mm/yyyy") : String.Empty; ;
            model.TotalVolume = String.Format("{0:N0}", totalVolume);
            model.MaxVolume = String.Format("{0:N0}", maxVolume);
        }

        private String GetFarol(ContractStatus? status)
        {
            if (status == null)
                return ResourceMap.DASH;

            return ResourceMap.GetContractIcon(status.Value);
        }

        private String GetEndorsementIcon(EndorsementStatus? status)
        {
            if (status == null)
                return ResourceMap.DASH;

            return ResourceMap.GetEndorsementIcon(status.Value);
        }

        
    }
}
