using System;

namespace Dominio.Entidades.Acesso
{
    public class AssociacaoGrupoUsuario
    {
        public int UsuarioId { get; set; }

        public int GrupoUsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual GrupoUsuario Grupo { get; set; }
    }
}