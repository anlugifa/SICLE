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

        [MaxLength(255)]
        [EmailAddress]
        public String Nickname {get; set;}
        public String Observation {get; set;}
        public Boolean IsActive {get; set;}
        public DateTime CreationDate {get; set;}

        public int CreationUserId {get; set;}
        public Usuario CreationUser {get; set;}

        
        public ICollection<ContratoVenda> Contratos {get; set;}
    }
}
