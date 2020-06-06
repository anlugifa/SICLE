using Dominio.Entidades.Acesso;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sicle.Web.Models;

namespace Sicle.Web.Areas.Acessos.Models
{
    public class AssociacaoUsuarioPerfilModel : PaginatedList<AssociacaoUsuarioPerfil>
    {
        public IList<Perfil> Perfis{ get; set; }
        public IList<Usuario> Usuarios { get; set; }

        public int PerfilId { get; set; }

        public int UsuarioId { get; set; }

        public AssociacaoUsuarioPerfilModel(List<AssociacaoUsuarioPerfil> items, 
            int count, int pageIndex) : base(items, count, pageIndex, _pageSize)
        {
        }
    }
}
