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
using Dominio.Entidades.Contrato;
using Sicle.Web.Areas.Contratos.Models;

namespace Web.Controllers
{
    [Area("Contratos")]
    public class ContratoVendaMestreController : SicleController
    {
        private readonly ContratoVendaMestreRepository _repo;

        public ContratoVendaMestreController(ApplicationDBContext context) : base(context)
        {
            _repo = new ContratoVendaMestreRepository(context);
        }  

        public async Task<IActionResult> Index(int contratoId, 
                                                string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewData["ContratoId"] = contratoId;
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
                query = query.Where(s => s.Nickname.Contains(searchString)
                                       || s.Observation.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Nickname);
                    break;
                case "matricula_desc":
                    query = query.OrderBy(s => s.CreationDate);
                    break;                
                default:
                    query = query.OrderBy(s => s.Nickname);
                    break;
            }

            return View(await ContratoVendaMestreModel
                        .CreateAsync(query.Include("Contratos").AsNoTracking(), pageNumber ?? 1, _pageSize));
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
            return View(new ContratoVendaMestre());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(ContratoVendaMestre modelo)
        {
            if (ValidateModel())
            {              
                await _repo.SaveOrUpdate(modelo);
            }

            ViewBag.SuccessMsg = "Contrato salvo com sucesso!"; 
            return View(modelo);
        }
    }
}