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

        internal void HandleSearchVariable(
                                    string sortOrder,
                                    string currentFilter,
                                    string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CodeSortParm"] = sortOrder == "code_desc" ? "code_desc" : "name_desc";            

            ViewData["CurrentFilter"] = searchString;
        }

        internal IQueryable<Perfil> Sort(IQueryable<Perfil> query, string sortOrder)
        {
            switch (sortOrder)
            {
                case "code_desc":
                    return query.OrderByDescending(s => s.Code);
                    
                case "name_desc":
                    return query.OrderByDescending(s => s.Nome);
                   
                default:
                    return query.OrderBy(s => s.Nome);
                   
            }
        }
        
        public async Task<IActionResult> Index( string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {            

            if (pageNumber > 1 && String.IsNullOrEmpty(searchString))
            {
                searchString = currentFilter;
            }
            HandleSearchVariable(sortOrder, currentFilter, searchString);

            var perfis =  new PerfilBus().AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                perfis = perfis.Where(s => s.Nome.Contains(searchString)
                                       || s.Code.Contains(searchString));
            }

            perfis = Sort(perfis, sortOrder);

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