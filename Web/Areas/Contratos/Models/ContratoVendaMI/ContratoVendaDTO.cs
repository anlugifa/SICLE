using System;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Acesso;
using Dominio.Entidades.Contrato;
using Dominio.Entidades.Produtos;
using Sicle.Web.Util;
using Util;

namespace Sicle.Web.Areas.Contratos.Models
{
    public class ContratoVendaDTO
    {
        public long Id { get; set; }

        public long? ContratoMestreId { get; set; }
        public virtual String ContratoMestre { get; set; } = null!;

        [Display(Name = "Nome")]
        public String Name { get; set; } = null!;

        [Display(Name = "Apelido")]
        public String Nickname { get; set; } = null!;

        [Display(Name = "Início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Begin { get; set; }

        [Display(Name = "Fim")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [Required(ErrorMessage = "Safra obrigatório")]
        public String Safra { get; set; } = null!;

        public int? ProductGroupId { get; set; }
        public virtual String ProductGroup { get; set; } = null!;

        public long? ClientGroupId { get; set; }
        public virtual String ClientGroup { get; set; } = null!;

        public long? PaymentTermId { get; set; }
        public virtual String PaymentTerm { get; set; } = null!;

        public virtual Nullable<PeriodType> Period { get; set; }

        public String BrokerId { get; set; } = null!;

        public long? TraderId { get; set; }
        public virtual String Trader { get; set; } = null!;

        public virtual String Observation { get; set; } = null!;

        public bool IsAvailableForBroker { get; set; }
        public bool IsActive { get; set; }

        public Boolean HasNegotiationBC { get; set; }
        public Boolean IsOperacaoNNE { get; set; }

        public DateTime? CreationDate { get; set; }
        public long? CreationUserId { get; set; }



    }
}
