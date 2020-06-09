using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dados.Repository;
using Dominio.Entidades.Acesso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sicle.Web.Controllers;
using Sicle.Web.Models;
using Sicle.Business.Admin;

namespace Sicle.Web.Controllers.Acesso
{
    [Area("Acessos")]
    public class PerfilController : SicleController
    {
        public PerfilController()  : base()
        {            
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

            var perfis =  new PerfilBus().AsQueryable();

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

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var item = new PerfilBus().Get(id);

            return View("Salvar", item);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int id)
        {
            await new PerfilBus().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View(new Perfil());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(Perfil modelo)
        {
            if (ValidateModel())
            {
                await new PerfilBus().SaveOrUpdate(modelo);
            }
            ViewBag.SuccessMsg = "Perfil salvo com sucesso!";
            return View(modelo);
        }
    }
}