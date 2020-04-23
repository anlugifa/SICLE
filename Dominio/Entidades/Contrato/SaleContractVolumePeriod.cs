using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Localidades;

namespace Dominio.Entidades.Contrato
{
    public class SaleContractVolumePeriod
    {
        public long Id { get; set; }

        public Decimal Volume { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Week { get; set; }

        public long? SaleQuotaId { get; set; }
        public SaleContractQuota SaleQuota { get; set; }
    }
}