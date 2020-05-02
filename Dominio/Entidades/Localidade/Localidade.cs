using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Localidades
{
    public abstract class Localidade : ILocalidade
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; } = null!;
        
        [Required]
        public String Code { get; set; } = null!;

        [Required]
        public TipoLocalidade Tipo { get; set; }
    }
}
