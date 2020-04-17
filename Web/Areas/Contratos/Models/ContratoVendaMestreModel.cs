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
    public class ContratoVendaMestreModel : PaginatedList<ContratoVendaMestre>
    {
        public String Farol { get; set; }
        public String EndorsementIcon { get; set; }
        public ContractStatus ContractStatus { get; set; }
        public EndorsementStatus EndorsementStatus { get; set; }
        public String MinDate { get; set; }
        public String MaxDate { get; set; }
        public String TotalVolume { get; set; }
        public String MaxVolume { get; set; }

        public ContratoVendaMestreModel(List<ContratoVendaMestre> items,
            int count, int pageIndex, int pageSize) : base(items, count, pageIndex, pageSize)
        {
        }

        public static new async Task<ContratoVendaMestreModel> CreateAsync(IQueryable<ContratoVendaMestre> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new ContratoVendaMestreModel(items, count, pageIndex, pageSize);
        }

        protected ContractStatus GetContractStatus(ContractStatus status, ContratoVenda contract)
        {
            switch (contract.Status)
            {
                case ContractStatus.APPROVED:
                    if (!(status == ContractStatus.MODIFIED_IN_APPROVAL) ||
                            status == ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.APPROVED;
                    }
                    break;
                case ContractStatus.REJECTED:
                    if (!(status == ContractStatus.MODIFIED_IN_APPROVAL) ||
                            status == ContractStatus.APPROVED ||
                            status == ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.REJECTED;
                    }
                    break;
                case ContractStatus.CREATED_IN_APPROVAL:
                    return ContractStatus.CREATED_IN_APPROVAL;

                case ContractStatus.MODIFIED_IN_APPROVAL:
                    if (!(status == ContractStatus.CREATED_IN_APPROVAL))
                    {
                        return ContractStatus.MODIFIED_IN_APPROVAL;
                    }
                    break;
                case ContractStatus.REMOVED:
                    if (status != ContractStatus.MODIFIED_IN_APPROVAL &&
                        status != ContractStatus.APPROVED &&
                        status != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.REMOVED;
                    }
                    break;
                default:
                    break;
            }

            return ContractStatus.REJECTED;
        }

        protected EndorsementStatus GetEndosementStatus(EndorsementStatus status, ContratoVenda contract)
        {
            switch (contract.EndorsementStatus)
            {
                case EndorsementStatus.ENDORSED:
                    if (status != EndorsementStatus.IN_ENDORSEMENT)
                    {
                        return EndorsementStatus.ENDORSED;
                    }
                    break;
                case EndorsementStatus.IN_ENDORSEMENT:
                    return EndorsementStatus.IN_ENDORSEMENT;

                case EndorsementStatus.NOT_NECESSARY:
                    if (status != EndorsementStatus.IN_ENDORSEMENT &&
                       status != EndorsementStatus.ENDORSED)
                    {
                        return EndorsementStatus.NOT_NECESSARY;
                    }
                    break;
                case EndorsementStatus.UNVALUED:
                    if (status != EndorsementStatus.IN_ENDORSEMENT)
                    {
                        return EndorsementStatus.UNVALUED;
                    }
                    break;
                case EndorsementStatus.NONE:
                    if (status != EndorsementStatus.IN_ENDORSEMENT &&
                        status != EndorsementStatus.NOT_NECESSARY &&
                        status != EndorsementStatus.ENDORSED &&
                        status != EndorsementStatus.UNVALUED)
                    {
                        return EndorsementStatus.NONE;
                    }
                    break;
            }

            return EndorsementStatus.NONE;
        }

        public void PrepareRowToShow(ContratoVendaMestre model)
        {
            ContractStatus status = ContractStatus.REJECTED;
            EndorsementStatus endorsementStatus = EndorsementStatus.NONE;
            Double totalVolume = 0;
            Double maxVolume = 0;
            DateTime? minDate = null;
            DateTime? maxDate = null;

            foreach (ContratoVenda contract in model.Contratos)
            {
                status = GetContractStatus(status, contract);
                endorsementStatus = GetEndosementStatus(endorsementStatus, contract);

                Double? realVolume = contract.HasForecast ? contract.MaxForecast.Value : contract.TotalVolume;
                if (realVolume.HasValue && realVolume.Value > maxVolume)
                {
                    maxVolume = realVolume.Value;
                }

                totalVolume += (realVolume.HasValue ? realVolume.Value : 0);

                if (minDate == null || DateTime.Compare(contract.Begin, minDate.Value) < 0)
                {
                    minDate = contract.Begin;
                }

                if (maxDate == null || DateTime.Compare(contract.End, maxDate.Value) > 0)
                {
                    maxDate = contract.End;
                }
            }

            FinalRowResult(status, endorsementStatus, minDate, maxDate, totalVolume, maxVolume);
        }

        private void FinalRowResult(ContractStatus status,
                    EndorsementStatus endorsementStatus,
                    DateTime? minDate,
                    DateTime? maxDate,
                    double totalVolume,
                    double maxVolume)
        {
            Farol = GetFarol(status);
            EndorsementIcon = GetEndorsementIcon(endorsementStatus);

            ContractStatus = status;
            EndorsementStatus = endorsementStatus;
            MinDate = minDate.HasValue ? minDate.Value.ToString("dd/mm/yyyy") : String.Empty;
            MaxDate = maxDate.HasValue ? maxDate.Value.ToString("dd/mm/yyyy") : String.Empty;;
            TotalVolume = String.Format("{0:N0}", totalVolume);
            MaxVolume = String.Format("{0:N0}", maxVolume);
        }

        private String GetFarol(ContractStatus status)
        {

            switch (status)
            {
                case ContractStatus.APPROVED:
                    return ResourceMap.CIRCLE_GREEN;
                case ContractStatus.REJECTED:
                    return ResourceMap.CIRCLE_RED;
                case ContractStatus.CREATED_IN_APPROVAL:
                    return ResourceMap.CIRCLE_YELLOW;
                case ContractStatus.MODIFIED_IN_APPROVAL:
                    return ResourceMap.CIRCLE_YELLOW;
                case ContractStatus.REMOVED:
                    return ResourceMap.CIRCLE_RED;
                default:
                    return ResourceMap.CIRCLE_GRAY;
            }
        }

        private String GetEndorsementIcon(EndorsementStatus status)
        {
            switch (status) 
            {
                case EndorsementStatus.ENDORSED:
                    return ResourceMap.CIRCLE_GREEN;
                case EndorsementStatus.IN_ENDORSEMENT:
                    return ResourceMap.CIRCLE_YELLOW;
                case EndorsementStatus.NOT_NECESSARY:
                    return ResourceMap.CIRCLE_GRAY;
                case EndorsementStatus.UNVALUED:
                    return ResourceMap.DASH;
                case EndorsementStatus.NONE:
                    return ResourceMap.DASH;
                default:
                    return ResourceMap.DASH;
                }
	
        }

        public String GetId(ContratoVendaMestre model)
        {
            return "RM-" + model.Id;
        }
    }
}
