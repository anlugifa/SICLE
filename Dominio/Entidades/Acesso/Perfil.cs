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
        public string Code { get; set; }

        [MaxLength(40)]
        public string Nome { get; set; }

        public int Volume { get; set; }

        public int Prazo { get; set; }

        public float Preco { get; set; }

        public PurchaseRating Rating { get; set; }

        public float VolumeContrato { get; set; }

        public float VolumeComplemento { get; set; }

        public ProfileLevel ProfileLevel { get; set; }

        public ICollection<AssociacaoUsuarioPerfil> Usuarios { get; set; }

        public Decimal VlVolumeEnergia { get; set; }
        public float VlVolumeContratoEnergia { get; set; }
        public float VlVolumeImportacao { get; set; }
        public float VlPrecoEnergia { get; set; }
        public Decimal VlPrazoEnergia { get; set; }
        public float VlVolumeComplementoEnergia { get; set; }
        public float VlVolumeMaxPurchaseDetivatives { get; set; }
        public float VlVolumeMaxOrderDerivatives { get; set; }
        public float VlVolumeMaxOrderSubproduct { get; set; }
        public float VlVolumeMaxPurchaseSubproduct { get; set; }
        public Decimal MaxPeriodImportContract { get; set; }

        public Decimal MaxPeriodContract { get; set; }

        public bool IsProvisionApprover { get; set; }
        public Decimal MaxCreditLimit { get; set; }
    }
}