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

        public SaleType SaleType { get; set; }

        public long? ContratoId { get; set; }
        public SaleContract Contrato { get; set; } = null!;
        
        public int? OrigemId { get; set; }       
        public Regiao Origem { get; set; }  = null!;

        public int? DestinoId { get; set; }
        public Client Destino { get; set; }  = null!;

        public ICollection<SaleContractVolumePeriod> VolumePeriods { get; set; }  = null!;

        public SaleContractQuota()
        {
            
        }

        public String GetNameQuota()
        {
            return GetOriginInitials() + " -> " + GetDestinationInitials() + " (" + SaleType + ")";
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