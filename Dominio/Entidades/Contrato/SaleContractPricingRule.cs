//#nullable enable

using System;
using System.Collections.Generic;
using Dominio.Entidades.Pricing;

namespace Dominio.Entidades.Contrato
{
    public class SaleContractPricingRule
    {
        public long Id { get; set; }
        public long? ParentRuleId { get; set; }

        public String Name { get; set; }        
        public Double? FlatPrice { get; set; }
        public Double? NetDiscount { get; set; }
        public Double? NetDiscountPercent { get; set; }
        public Double? GrossDiscount { get; set; }
        public Double? GrossDiscountPercent { get; set; }
        public Double? Rebate { get; set; }

        public String Details { get; set; } = null!;

        public bool IsEsalqCurrent { get; set; }
        public bool IsCumulativeNetDiscount { get; set; }
        public bool IsCumulativeGrossDiscount { get; set; }
        public bool IsRebateWithinTaxes { get; set; }
        public bool IsWeeklyAverage { get; set; }        

        public EsalqType EsalqType { get; set; }
        public PeriodType EsalqPeriodType { get; set; }
        public PricingType PricingType { get; set; }
        public PricingIncidenceType DiflogIncidenceType { get; set; }
        public PricingIncidenceType FreightIncidenceType { get; set; }
        public PrecoPBPeriodType PrecoPBPeriodType { get; set; }
        public PricingAdjustReferenceType? AdjustReferenceType { get; set; }

        public long ContratoVendaId { get; set; }
        public ContratoVenda ContratoVenda { get; set; }

        public String EsalqDescriptionId { get; set; }
        public EsalqDescription EsalqDescription { get; set; }        

        public long? PrecoPBModalId { get; set; }
        public PrecoPBModal PrecoPBModal { get; set; }

        public long? PrecoPBDescriptionId { get; set; }
        public PrecoPBDescription PrecoPBDescription { get; set; }

        public long? PrecoPBProductId { get; set; }
        public PrecoPBProduct PrecoPBProduct { get; set; }

        public ICollection<OpenBookCost> OpenBookList { get; set; }
    }
}