using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Acesso
{
    public class PerfilVenda
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string Code { get; set; }

        [MaxLength(20)]
        public string Nome { get; set; }

        public Decimal? VlVolume { get; set; }

        public Decimal? VlVolumeContrato { get; set; }

        public Decimal? VlVolumeComplemento { get; set; }

        public Decimal? VlVolumeMaxOrderContrato { get; set; }
        
        public float? VlValorComplementoPreco { get; set; }

        public float? VlVolumeMaxOrderDerivatives { get; set; }

        public float? VlVolumeMaxOrderSubproduct { get; set; }

        public int? VlPrazo { get; set; }

        public int? MaxPeriodSaleForeignContract { get; set; }

        public int? MaxPeriodSaleContract { get; set; }

        public bool IsContractPriceApprover { get; set; }

        public bool IsProvisionApprover { get; set; }

        public bool IsForecastApprover { get; set; }

        public bool IsYnorFromYcnrApprover { get; set; }
        public bool IsComplementApprover { get; set; }

        public bool IsFinanceEndorsement { get; set; }

        public ProfileLevel? ProfileLevel { get; set; }

        public ICollection<AssociacaoUsuarioPerfilVenda> Usuarios { get; set; }

        public override String ToString()
        {
            return Code + "-" + Nome;
        }
    }
}