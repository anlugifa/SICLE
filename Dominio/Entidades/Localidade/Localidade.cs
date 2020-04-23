using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidades
{
    public abstract class Localidade
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }
        
        [Required]
        public String Code { get; set; }

        [Required]
        public TipoLocalidade Tipo { get; set; }
    }
}
