using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades.Contrato;

namespace Dominio.Entidades.Acesso
{
    public class Usuario
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Matrícula obrigatória")]
        [MaxLength(8)]
        public string Matricula { get; set; } = null!;

        [MaxLength(50)]
        [Required(ErrorMessage = "Nome obrigatória")]
        [Display(Name="Nome:")]
        public string Nome { get; set; } = null!;
        
        [MaxLength(50)]
        [Display(Name = "Nome SGP")]
        public string NomeSGP { get; set; } = null!;

        [Required(ErrorMessage = "E-mail obrigatória")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public bool IsScaPerfil { get; set; }

        public bool IsAtivo { get; set; }

        public bool IsTraderComb { get ; set; }

        public bool IsTraderEAB { get; set; }

        public ICollection<AssociacaoUsuarioPerfil> Perfis { get; set; } = null!;

        public ICollection<AssociacaoGrupoUsuario> Grupos { get; set; } = null!;

        public ICollection<AssociacaoUsuarioPerfilVenda> PerfilVendas { get; set; } = null!;

        public ICollection<ContratoVendaMestre> ContratosMestres { get; set; } = null!;

        // public ICollection<ContratoVenda> ContratosVendas { get; set; }

        public override String ToString()
        {
            return Matricula + ":" + Nome;
        }

    }
}