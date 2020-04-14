using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Dados.Repository;

namespace Web.Controllers
{
    [Area("Acessos")]
    public class UsuarioController : SicleController
    {
        private readonly UsuarioRepository _repo;

        public UsuarioController(ApplicationDBContext context) : base(context)
        {
            _repo = new UsuarioRepository(context);
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

            var query = _repo.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Nome.Contains(searchString)
                                       || s.NomeSGP.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Nome);
                    break;
                case "matricula_desc":
                    query = query.OrderBy(s => s.Matricula);
                    break;                
                default:
                    query = query.OrderBy(s => s.Nome);
                    break;
            }

            return View(await PaginatedList<Usuario>
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1, _pageSize));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = _repo.Get(id);

            return View("Salvar", usuario);
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View(new Usuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(Usuario modelo)
        {
            if (ValidateModel())
            {              
                await _repo.SaveOrUpdate(modelo);
            }

            return View(modelo);
        }
    }
}