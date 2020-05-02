using Dominio.Entidades.Acesso;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Sicle.Web.Areas.Acessos.Models
{
    public class AssociacaoUsuarioPerfilVendaModel : PaginatedList<AssociacaoUsuarioPerfilVenda>
    {
        public IList<PerfilVenda> Perfis{ get; set; }
        public IList<Usuario> Usuarios { get; set; }

        public int PerfilVendaId { get; set; }

        public int UsuarioId { get; set; }

        public AssociacaoUsuarioPerfilVendaModel(List<AssociacaoUsuarioPerfilVenda> items, 
            int count, int pageIndex) : base(items, count, pageIndex, _pageSize)
        {
        }
    }
}
