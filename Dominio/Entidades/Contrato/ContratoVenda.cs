using System;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Produtos;

namespace Dominio.Entidades.Contrato
{
    ///
    // Mapeado no Sicle como SaleContract
    ///
    public class ContratoVenda
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public double Flexibility { get; set; }
        public double TotalVolume { get; set; }
        public String EconomicGroup { get; set; }
        public bool IsAvailableForBroker { get; set; }
        public String Observation { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public String Nickname { get; set; }
        public String Safra { get; set; }
        public String Reason { get; set; }
        public DateTime CreationDate { get; set; }        
        public DateTime DateOfApproval { get; set; }
        public String Approver { get; set; }
        public DateTime DateOfTradingApproval { get; set; }
        public String TradingApprover { get; set; }
        public DateTime DateOfFinancesApproval { get; set; }
        public String FinancesApprover { get; set; }
        public int ContractVersion { get; set; }

        public Boolean HasForecast { get; set; }
        public double MaxForecast { get; set; }

        public Boolean HasNegotiationBC { get; set; }
        public Boolean IsOperacaoNNE { get; set; }

        public int CreationUserId { get; set; }
        public virtual Usuario CreationUser { get; set; }
        
        public int EditorId { get; set; }
        public virtual Usuario Editor { get; set; }

        public int TraderId { get; set; }
        public virtual Usuario Trader { get; set; }
        
        public int BrokerId { get; set; }
        public virtual Broker Broker { get; set; }
        
        public int ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        
        public virtual ContractStatus Status { get; set; }
        public virtual EndorsementStatus EndorsementStatus { get; set; }
        public virtual PeriodType Period { get; set; }

        public int ClientGroupId { get; set; }
        public virtual ClientGroup ClientGroup { get; set; }

        public int PaymentTermId { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }

        public long ContratoMestreId { get; set; }
        public virtual ContratoVendaMestre ContratoMestre { get; set; }

        public ContratoVenda()
        {
            ContractVersion = 1;
        }
    }
}
