using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    ///
    // Mapeado no Sicle como SaleContract
    ///
    public class ContratoVenda
    {
        public long Id { get; set; }
        public long? ContratoVendaAnteriorId { get; set; }
        public String Name { get; set; }
        public String Nickname { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public double Flexibility { get; set; }
        public double? TotalVolume { get; set; }
        public String EconomicGroup { get; set; }
        public bool IsAvailableForBroker { get; set; }
        public String Observation { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        
        public String Safra { get; set; }
        public String Reason { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CreationDate { get; set; }        

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfApproval { get; set; }        

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfTradingApproval { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfFinancesApproval { get; set; }

        public String Approver { get; set; }
        public String TradingApprover { get; set; }        
        public String FinancesApprover { get; set; }
        public long ContractVersion { get; set; }
        public double? MaxForecast { get; set; }
        public Boolean HasForecast { get; set; }        
        public Boolean HasNegotiationBC { get; set; }
        public Boolean IsOperacaoNNE { get; set; }

        public virtual ContractStatus Status { get; set; }   
        public virtual Nullable<PeriodType> Period { get; set; }
        public virtual EndorsementStatus EndorsementStatus { get; set; }

        public long? CreationUserId { get; set; }
        public virtual Usuario CreationUser { get; set; }
        
        public long? EditorId { get; set; }
        public virtual Usuario Editor { get; set; }

        public long? TraderId { get; set; }
        public virtual Usuario Trader { get; set; }
        
        public String BrokerId { get; set; }
        public virtual Broker Broker { get; set; }
        
        public long? ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }

        public long? ClientGroupId { get; set; }
        public virtual ClientGroup ClientGroup { get; set; }

        public long? PaymentTermId { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }

        public long? ContratoMestreId { get; set; }
        public virtual ContratoVendaMestre ContratoMestre { get; set; }

        public ContratoVenda()
        {
            ContractVersion = 1;
        }
    }
}
