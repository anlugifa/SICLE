using System;

namespace Dominio.Entidades.Acesso
{
    public class AssociacaoUsuarioPerfil
    {
        public int UsuarioId { get; set; }

        public int PerfilId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}