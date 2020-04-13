using System;

namespace Dominio.Entidades.Acesso
{
    public class AssociacaoUsuarioPerfilVenda
    {
        public int UsuarioId { get; set; }

        public int PerfilVendaId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual PerfilVenda PerfilVenda { get; set; }
    }
}