using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dados.Repository;
using Dominio.Entidades.Acesso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Controllers;
using Web.Models;

namespace Sicle.Web.Controllers.Acesso
{
    [Area("Acessos")]
    public class PerfilController : SicleController
    {
        private readonly PerfilRepository _repo;

        public PerfilController(ApplicationDBContext context)  : base(context)
        {
            _repo = new PerfilRepository(context);
        }
        
        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CodeSortParm"] = sortOrder == "code_desc" ? "code_desc" : "name_desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var perfis = _repo.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                perfis = perfis.Where(s => s.Nome.Contains(searchString)
                                       || s.Code.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "code_desc":
                    perfis = perfis.OrderByDescending(s => s.Code);
                    break;
                case "name_desc":
                    perfis = perfis.OrderByDescending(s => s.Nome);
                    break;
                default:
                    perfis = perfis.OrderBy(s => s.Nome);
                    break;
            }

            int pageSize = 20;
            return View(await PaginatedList<Perfil>
                        .CreateAsync(perfis.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}