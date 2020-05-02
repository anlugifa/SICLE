using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Acesso
{
    public class GrupoUsuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public String Code { get; set; } = null!;
            
        [MaxLength(50)]
        public String Nome { get; set; } = null!;

        public ICollection<AssociacaoGrupoUsuario> Usuarios { get; set; } = null!;
    }
}