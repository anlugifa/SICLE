using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Acesso
{
    public class Perfil
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string Code { get; set; } = null!;

        [MaxLength(40)]
        public string Nome { get; set; } = null!;

        public int? Volume { get; set; }

        public int? Prazo { get; set; }

        public Decimal? Preco { get; set; }
        public Decimal? VolumeContrato { get; set; }
        public Decimal? VolumeComplemento { get; set; }
        public Decimal? VlVolumeEnergia { get; set; }
        public Decimal? VlVolumeContratoEnergia { get; set; }
        public Decimal? VlVolumeImportacao { get; set; }
        public Decimal? VlPrecoEnergia { get; set; }
        public Decimal? VlPrazoEnergia { get; set; }
        public Decimal? VlVolumeComplementoEnergia { get; set; }
        public Decimal? VlVolumeMaxPurchaseDetivatives { get; set; }
        public Decimal? VlVolumeMaxOrderDerivatives { get; set; }
        public Decimal? VlVolumeMaxOrderSubproduct { get; set; }
        public Decimal? VlVolumeMaxPurchaseSubproduct { get; set; }
        public Decimal? MaxPeriodImportContract { get; set; }

        public Decimal? MaxPeriodContract { get; set; }
        public bool IsProvisionApprover { get; set; }
        public Decimal? MaxCreditLimit { get; set; }
        public PurchaseRating? Rating { get; set; }
        public ProfileLevel? ProfileLevel { get; set; }
        public ICollection<AssociacaoUsuarioPerfil> Usuarios { get; set; } = null!;
    }
}