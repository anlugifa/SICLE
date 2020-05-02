using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Localidades;
using Dominio.Entidades.Pricing;

namespace Dominio.Entidades.Contrato
{
    public class MapPricingRule_PricingPeriod
    {
        public long PricingRuleId { get; set; }
        public SaleContractPricingRule SaleContractPricingRule { get; set; } = null!;

        public long PricingPeriodId { get; set; }
        public SaleContractPricingPeriod SaleContractPricingPeriod { get; set; } = null!;
    }
}