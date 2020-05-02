using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Acesso;

namespace Dominio.Entidades.Contrato
{
    public class ContratoVendaMestre
    {
        [Required]
        [MaxLength(30)]
        public long Id {get; set;}

        [Obsolete("Utilizado em heranças pelo Sicle antigo.")]
        public String Discriminator {get; set;} = "MasterSaleContract";

        [MaxLength(255)]
        [Required(ErrorMessage="Apelido é obrigatório.")]
        [Display(Name="Apelido")]
        public String Nickname {get; set;} = null!;

        [Display(Name="Observação")]
        public String Observation {get; set;} = null!;

        public Boolean IsActive {get; set;}

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime CreationDate {get; set;}

        public long CreationUserId {get; set;}
        public Usuario CreationUser {get; set;} = null!;
        
        public ICollection<ContratoVenda> Contratos {get; set;} = null!;

        public override string ToString()
        {
            return "RM-" + Id;
        }
    }
}
