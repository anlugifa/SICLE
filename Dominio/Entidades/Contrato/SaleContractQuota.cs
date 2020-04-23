using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Entidades.Localidades;

namespace Dominio.Entidades.Contrato
{
    public class SaleContractQuota
    {
        public long Id { get; set; }

        public double? QuotaVolume { get; set; }
        public double? TotalVolume { get; set; }

        public double? Diflog { get; set; }

        public double? Freight { get; set; }

        public SaleType Type { get; set; }

        public long? ContratoId { get; set; }
        public ContratoVenda Contrato { get; set; }
        
        public int? OrigemId { get; set; }       
        public Localidade Origem { get; set; }

        public int? DestinoId { get; set; }
        public Client Destino { get; set; }

        public ICollection<SaleContractVolumePeriod> VolumePeriods { get; set; }

        public String GetNameQuota()
        {
            return GetOriginInitials() + " -> " + GetDestinationInitials() + " (" + Type + ")";
        }

        public String GetOriginInitials()
        {
            return Origem == null ? "" : Origem.Name;
        }

        public String GetDestinationInitials()
        {
            return Destino == null ? "" : Destino.Code + " - " + Destino.Name;
        }
    }
}