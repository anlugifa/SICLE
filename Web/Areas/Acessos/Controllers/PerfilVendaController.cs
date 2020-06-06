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

namespace Sicle.Web.Controllers.Acesso
{
    [Area("Acessos")]
    public class PerfilVendaController : SicleController
    {
        private readonly PerfilVendaRepository _repo;

        public PerfilVendaController(ApplicationDBContext context) : base(context)
        {
            _repo = new PerfilVendaRepository(context);
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
            return View(await PaginatedList<PerfilVenda>
                        .CreateAsync(perfis.AsNoTracking(), pageNumber ?? 1, pageSize));
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
            return View(new PerfilVenda());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(PerfilVenda modelo)
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