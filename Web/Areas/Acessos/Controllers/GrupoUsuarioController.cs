using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dados.Repository;

namespace Web.Controllers
{
    [Area("Acessos")]
    public class GrupoUsuarioController : SicleController
    {
        private readonly GrupoUsuarioRepository _repo;

        public GrupoUsuarioController(ApplicationDBContext context) : base(context)
        {
            _log.Info("Controller: GrupoUsuarioController");

            _repo = new GrupoUsuarioRepository(context);
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
                                       || s.Code.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Nome);
                    break;
                case "matricula_desc":
                    query = query.OrderBy(s => s.Code);
                    break;                
                default:
                    query = query.OrderBy(s => s.Nome);
                    break;
            }

            return View(await PaginatedList<GrupoUsuario>
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1, _pageSize));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var item = _repo.Get(id);

            return View("Salvar", item);
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
            return View(new GrupoUsuario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(GrupoUsuario modelo)
        {
            if (ValidateModel())
            {
                await _repo.SaveOrUpdate(modelo);
            }

            ViewBag.SuccessMsg = "Perfil salvo com sucesso!";
            return View(modelo);
        }
    }
}