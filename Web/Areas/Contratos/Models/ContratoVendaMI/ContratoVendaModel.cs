using System;
using Dominio.Entidades.Contrato;
using Sicle.Web.Util;
using Util;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class ContratoVendaModel
    {
        public ContratoVenda Contrato { get; set; }

        public string Farol { get; set; }
        public string MaskId { get; set; }
        public string Nome { get; set; }
        public string FarolEndosso { get; set; }
        public string StatusEndosso { get; set; }
        public string Apelido { get; set; }
        public string GrupoProduto { get; set; }   
        public string GrupoCliente { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public string Flexibilidade { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
        public string TotalVolume { get; set; }
        public string Periodicidade { get; set; }
        public string GrupoEconomico { get; set; }
        public string PrazoPagamento { get; set; }
        public bool IsDisponivelBroker { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsPrevisao { get; set; }
        public string PrevisaoMax { get; set; }

        
        

        public ContratoVendaModel(ContratoVenda contrato)
        {
            this.Contrato = contrato;

            FillFields();
        }

        private void FillFields()
        {
            
            Farol = getFarolIcon(Contrato.Status);
            MaskId =  Contrato.ToString();
            Nome = Contrato.Name;
            FarolEndosso = ResourceMap.GetEndorsementIcon(Contrato.EndorsementStatus);
            StatusEndosso = Contrato.EndorsementStatus.GetEnumDescription();
            Apelido = Contrato.Nickname;
            GrupoProduto = Contrato.ProductGroup.Code;
            GrupoCliente = Contrato.ClientGroup.Code;
            Inicio = Contrato.Begin.ToStr();
            Fim = Contrato.End.ToStr();
            Flexibilidade = Contrato.Flexibility.ToStr();
            Status = Contrato.Status.GetEnumDescription();
            Observacao = Contrato.Observation;
            TotalVolume = Contrato.TotalVolume.ToStr();
            Periodicidade = Contrato.Period.HasValue? Contrato.Period.GetEnumDescription() : "";
            GrupoEconomico = Contrato.EconomicGroup;
            PrazoPagamento = Contrato.PaymentTerm != null ? Contrato.PaymentTerm.Code : "";
            PrevisaoMax = Contrato.MaxForecast.ToStr();

            IsDisponivelBroker = Contrato.IsAvailableForBroker;
            IsAtivo = Contrato.IsActive;
            IsPrevisao = Contrato.HasForecast;
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
