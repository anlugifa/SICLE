using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Area("Acessos")]
    public class UsuarioController : SicleController
    { 
        public UsuarioController(ApplicationDBContext context) : base(context)
        {
        }  

        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["MatriculaSortParm"] = sortOrder == "matricula_desc" ? "name_desc" : "matricula_desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var usuarios = from s in _context.Usuarios
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(s => s.Nome.Contains(searchString)
                                       || s.NomeSGP.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    usuarios = usuarios.OrderByDescending(s => s.Nome);
                    break;
                case "matricula_desc":
                    usuarios = usuarios.OrderBy(s => s.Matricula);
                    break;                
                default:
                    usuarios = usuarios.OrderBy(s => s.Nome);
                    break;
            }

            int pageSize = 20;
            return View(await PaginatedList<Usuario>
                        .CreateAsync(usuarios.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}