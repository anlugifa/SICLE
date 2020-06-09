using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sicle.Web.Models;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sicle.Business.Admin;

namespace Sicle.Web.Controllers
{
    [Area("Acessos")]
    public class GrupoUsuarioController : SicleController
    {      

        public GrupoUsuarioController() : base()
        {
            _log.Info("Controller: GrupoUsuarioController");            
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

            var query = new GrupoUsuarioBus().AsQueryable();

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
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var item = new GrupoUsuarioBus().Get(id);

            return View("Salvar", item);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int id)
        {
            await new GrupoUsuarioBus().Delete(id);
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
                await new GrupoUsuarioBus().SaveOrUpdate(modelo);
            }

            ViewBag.SuccessMsg = "Perfil salvo com sucesso!";
            return View(modelo);
        }
    }
}