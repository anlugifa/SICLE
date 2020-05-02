using System;

namespace Dominio.Entidades.Acesso
{
    public class AssociacaoUsuarioPerfilVenda
    {
        public long UsuarioId { get; set; }

        public int PerfilVendaId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;

        public virtual PerfilVenda PerfilVenda { get; set; } = null!;
    }
}