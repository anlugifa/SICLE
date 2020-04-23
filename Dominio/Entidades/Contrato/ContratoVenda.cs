using System;
using System.Collections.Generic;
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

        [Display(Name = "Nome")]
        public String Name { get; set; }

        [Display(Name = "Apelido")]
        public String Nickname { get; set; }

        [Display(Name = "Início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Begin { get; set; }

        [Display(Name = "Fim")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Display(Name = "Flexibilidade")]
        public double Flexibility { get; set; }

        [Display(Name = "Vol. Total")]
        public double? TotalVolume { get; set; }

        [Display(Name = "Grupo Econômico")]
        public String EconomicGroup { get; set; }

        [Display(Name = "Observação")]
        public String Observation { get; set; }

        public bool IsAvailableForBroker { get; set; }
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

        public int? ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }

        public long? ClientGroupId { get; set; }
        public virtual ClientGroup ClientGroup { get; set; }

        public long? PaymentTermId { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }

        public long? ContratoMestreId { get; set; }
        public virtual ContratoVendaMestre ContratoMestre { get; set; }

        public virtual IEnumerable<SaleContractQuota> Quotas { get; set; }

        public ContratoVenda()
        {
            ContractVersion = 1;
        }

        public override string ToString()
        {
            return "RE-" + Id;
        }
    }
}
