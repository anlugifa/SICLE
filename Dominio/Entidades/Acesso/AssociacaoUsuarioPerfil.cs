using System;

namespace Dominio.Entidades.Acesso
{
    public class AssociacaoUsuarioPerfil
    {
        public long UsuarioId { get; set; }

        public int PerfilId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;

        public virtual Perfil Perfil { get; set; } = null!;
    }
}