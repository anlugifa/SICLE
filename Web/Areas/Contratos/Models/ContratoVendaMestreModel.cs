using System;
using Dominio.Entidades.Contrato;
using Web.Util;
using Util;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class ContratoVendaMestreModel
    {

        public ContratoVendaMestre ContratoMestre {get; set;}

        public String Id { get; set; }
        public String Farol { get; set; }
        public String EndorsementIcon { get; set; }
        public String StatusMestre { get; set; }
        public String EndossoMestre { get; set; }
        public String MinDate { get; set; }
        public String MaxDate { get; set; }
        public String TotalVolume { get; set; }
        public String MaxVolume { get; set; }  

        public ContratoVendaMestreModel(ContratoVendaMestre mestre)
        {
            this.ContratoMestre = mestre;

            FillFields();
        }

        private void FillFields()
        {            
            ContractStatus? mestreStatus = null;
            EndorsementStatus? mestreEndorsementStatus = null;
            Double totalVolume = 0;
            Double maxVolume = 0;
            DateTime? minDate = null;
            DateTime? maxDate = null;

            if (ContratoMestre.Contratos.Count > 0)
            {
                mestreStatus = ContractStatus.REJECTED;
                mestreEndorsementStatus = EndorsementStatus.NONE;
            }

            foreach (ContratoVenda contract in ContratoMestre.Contratos)
            {
                mestreStatus = GetContractStatus(mestreStatus, contract);
                mestreEndorsementStatus = GetEndosementStatus(mestreEndorsementStatus, contract);

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

            FinalRowResult(mestreStatus, mestreEndorsementStatus, minDate, maxDate, totalVolume, maxVolume);
        }

        private void FinalRowResult(ContractStatus? status,
                    EndorsementStatus? endorsementStatus,
                    DateTime? minDate,
                    DateTime? maxDate,
                    double totalVolume,
                    double maxVolume)
        {
            Id = ContratoMestre.ToString();
            Farol = GetFarol(status);
            EndorsementIcon = GetEndorsementIcon(endorsementStatus);

            StatusMestre = status.HasValue ? status.GetEnumDescription() : "";
            EndossoMestre = endorsementStatus.HasValue ? endorsementStatus.GetEnumDescription() : "";
            MinDate = minDate.HasValue ? minDate.Value.ToString("dd/mm/yyyy") : String.Empty;
            MaxDate = maxDate.HasValue ? maxDate.Value.ToString("dd/mm/yyyy") : String.Empty;;
            TotalVolume = String.Format("{0:N0}", totalVolume);
            MaxVolume = String.Format("{0:N0}", maxVolume);
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

        protected ContractStatus? GetContractStatus(ContractStatus? statusMestre, ContratoVenda contract)
        {
            switch (contract.Status)
            {
                case ContractStatus.APPROVED:
                    if (statusMestre != ContractStatus.MODIFIED_IN_APPROVAL &&
                        statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.APPROVED;
                    }
                    break;
                case ContractStatus.REJECTED:
                    if (statusMestre != ContractStatus.MODIFIED_IN_APPROVAL &&
                        statusMestre != ContractStatus.APPROVED &&
                        statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.REJECTED;
                    }
                    break;
                case ContractStatus.CREATED_IN_APPROVAL:
                    return ContractStatus.CREATED_IN_APPROVAL;

                case ContractStatus.MODIFIED_IN_APPROVAL:
                    if (statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.MODIFIED_IN_APPROVAL;
                    }
                    break;
                case ContractStatus.REMOVED:
                    if (statusMestre != ContractStatus.MODIFIED_IN_APPROVAL &&
                        statusMestre != ContractStatus.APPROVED &&
                        statusMestre != ContractStatus.CREATED_IN_APPROVAL)
                    {
                        return ContractStatus.REMOVED;
                    }
                    break;
                default:
                    break;
            }

            return null;
        }
		
		protected EndorsementStatus? GetEndosementStatus(EndorsementStatus? status, ContratoVenda contract)
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

            return null;
        }
    }
}