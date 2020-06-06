using Dominio.Entidades.Acesso;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sicle.Web.Models;

namespace Sicle.Web.Areas.Acessos.Models
{
    public class AssociacaoGrupoUsuarioModel : PaginatedList<AssociacaoGrupoUsuario>
    {
        public IList<GrupoUsuario> Grupos { get; set; }
        public IList<Usuario> Usuarios { get; set; }

        public int GrupoId { get; set; }

        public int UsuarioId { get; set; }

        public AssociacaoGrupoUsuarioModel(List<AssociacaoGrupoUsuario> items, 
            int count, int pageIndex) : base(items, count, pageIndex, _pageSize)
        {
        }
    }
}
