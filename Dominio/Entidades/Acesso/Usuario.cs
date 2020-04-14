using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.Acesso
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Matr�cula obrigat�ria")]
        [MaxLength(8)]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Nome obrigat�rio")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome SGP obrigat�rio")]
        [MaxLength(50)]
        [Display(Name = "Nome SGP")]
        public string NomeSGP { get; set; }

        [Required(ErrorMessage = "E-mail obrigat�rio")]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsScaPerfil { get; set; }

        public bool IsAtivo { get; set; }

        public bool IsTraderComb { get; set; }

        public bool IsTraderEAB { get; set; }

        public ICollection<AssociacaoUsuarioPerfil> Perfis { get; set; }

        public ICollection<AssociacaoGrupoUsuario> Grupos { get; set; }

        public ICollection<AssociacaoUsuarioPerfilVenda> PerfilVendas { get; set; }

        public override String ToString()
        {
            return Matricula + ":" + Nome;
        }

    }
}