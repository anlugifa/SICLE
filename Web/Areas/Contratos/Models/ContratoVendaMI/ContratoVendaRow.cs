using System;
using Dominio.Entidades.Contrato;
using Sicle.Web.Util;
using Util;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class ContratoVendaRow
    {
        public SaleContract Contrato { get; set; }

        public string Farol { get; set; }
        public string MaskId { get; set; }
        public string Name { get; set; }
        public string FarolEndorsement { get; set; }
        public string StatusEndorsement { get; set; }
        public string Nickname { get; set; }
        public string ProductGroup { get; set; }   
        public string ClientGroup { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }
        public string Flex { get; set; }
        public string Status { get; set; }
        public string Observation { get; set; }
        public string TotalVolume { get; set; }
        public string Period { get; set; }
        public string EconomicGroup { get; set; }
        public string PaymentTerm { get; set; }
        public bool IsAvailableForBroker { get; set; }
        public bool IsActive { get; set; }
        public bool IsForecast { get; set; }
        public bool IsNegotiationBC { get; set; }
        public string MaxForecast { get; set; }
        public string EmailStatus { get; set; }
        public string MasterContract { get; set; }      
        

        public ContratoVendaRow(SaleContract contrato)
        {
            this.Contrato = contrato;

            FillFields();
        }

        private void FillFields()
        {
            
            Farol = getFarolIcon(Contrato.Status);
            MaskId =  Contrato.ToString();
            Name = Contrato.Name;
            FarolEndorsement = ResourceMap.GetEndorsementIcon(Contrato.EndorsementStatus);
            StatusEndorsement = Contrato.EndorsementStatus.GetEnumDescription();
            Nickname = Contrato.Nickname;
            ProductGroup = Contrato.ProductGroup.ToString();
            ClientGroup = Contrato.ClientGroup.ToString();
            Begin = Contrato.Begin.ToStr();
            End = Contrato.End.ToStr();
            Flex = Contrato.Flexibility.ToStr();
            Status = Contrato.Status.GetEnumDescription();
            Observation = Contrato.Observation;
            TotalVolume = Contrato.TotalVolume.ToStr();
            Period = Contrato.Period.HasValue? Contrato.Period.GetEnumDescription() : "";
            EconomicGroup = Contrato.EconomicGroup;
            PaymentTerm = Contrato.PaymentTerm != null ? Contrato.PaymentTerm.Code : "";
            MaxForecast = Contrato.MaxForecast.ToStr();

            IsAvailableForBroker = Contrato.IsAvailableForBroker;
            IsActive = Contrato.IsActive;
            IsForecast = Contrato.HasForecast;
            IsNegotiationBC = Contrato.HasNegotiationBC;
            EmailStatus = ResourceMap.GetMailIcon(Contrato.MailStatus);

            MasterContract = Contrato.ContratoMestre == null ? String.Empty : Contrato.ContratoMestre.ToString();
        }

        public string getFarolIcon(ContractStatus status) 
        {            
            if(!Contrato.IsActive && status != ContractStatus.CREATED_IN_APPROVAL) {
                return  ResourceMap.CIRCLE_GRAY;
            }
            
            return ResourceMap.GetContractIcon(status);            
        }
    }

}
