using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Localidades;
using Dominio.Entidades.Pricing;

namespace Dominio.Entidades.Contrato
{
    public class SaleContractPricingPeriod
    {
        public long Id { get; set; }
        public int? Week { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public Double Flexibility { get; set; }

        public long ContratoVendaId { get; set; }
        public ContratoVenda Contrato { get; set; }

        public ICollection<MapPricingRule_PricingPeriod> MapPricingRules { get; set; }

    }
}
