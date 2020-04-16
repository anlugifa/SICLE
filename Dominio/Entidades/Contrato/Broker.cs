using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Contrato
{
    public class Broker
    {
        [Required]
        [MaxLength(30)]
        public String Code { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public String Email { get; set; }
    }
}
