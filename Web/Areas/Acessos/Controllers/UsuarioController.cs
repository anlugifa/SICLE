using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sicle.Web.Models;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Sicle.Business.Admin;

namespace Sicle.Web.Controllers
{
    [Area("Acessos")]
    public class UsuarioController : SicleController
    {
        public UsuarioController() : base()
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

            var query = new UsuarioBus().AsQueryable();

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
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = new UsuarioBus().Get(id);

            return View("Salvar", usuario);
        }

        [HttpGet]
        public  async Task<IActionResult> Remover(int id)
        {
            await new UsuarioBus().Delete(id);
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
                await new UsuarioBus().SaveOrUpdate(modelo);
            }

            ViewBag.SuccessMsg = "Usu�rio salvo com sucesso!"; 
            return View(modelo);
        }
    }
}