using System;

namespace Dominio.Entidades.Acesso
{
    public class AssociacaoGrupoUsuario
    {
        public long UsuarioId { get; set; }

        public int GrupoUsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;

        public virtual GrupoUsuario Grupo { get; set; } = null!;
    }
}