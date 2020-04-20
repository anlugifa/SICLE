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
        private readonly ContratoVendaRepository _repoContract;

        public ContratoVendaMestreController(ApplicationDBContext context) : base(context)
        {
            _repo = new ContratoVendaMestreRepository(context);
            _repoContract = new ContratoVendaRepository(context);
        }

        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string currentStatus,
                                                string searchString,
                                                ContractStatus? status,
                                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["ContratoIdSortParm"] = sortOrder == "id_asc" ? "id_desc" : "id_asc";
            ViewData["ApelidoSortParm"] = sortOrder == "apelido_asc" ? "apelido_desc" : "apelido_asc";
            
            #region pagination

            // salva status de filtros e ordenação para não perder valores na paginação
            if (!String.IsNullOrEmpty(searchString))
            {       
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            if (status != null)
            {       
                pageNumber = 1;
            }
            else
            {
                ContractStatus s;
                if (Enum.TryParse<ContractStatus>(currentStatus, true, out s))
                    status = s;
            }

            ViewData["CurrentStatus"] = status.ToString();
            
            #endregion

            #region filter
            var query = _repo.AsQueryable().Include("Contratos");
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Nickname.Contains(searchString)
                                       || s.Observation.Contains(searchString));
            }

            // if (status != null)
            // {
            //     query = query.Where(s => s.Contratos.Any(x => x.Status == status));
            // }
            #endregion

            switch (sortOrder)
            {
                case "id_asc":
                    query = query.OrderBy(s => s.Id);
                    break;
                case "id_desc":
                    query = query.OrderByDescending(s => s.Id);
                    break;
                case "apelido_asc":
                    query = query.OrderBy(s => s.Nickname);
                    break;
                case "apelido_desc":
                    query = query.OrderByDescending(s => s.Nickname);
                    break;
                default: // inicio_desc
                    query = query.OrderByDescending(s => s.Id);
                    break;
            }

            return View(await IndexContratoVendaMestreModel
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1, _pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id, string sortOrder, int? pageNumber)
        {
            var contrato = _repo.Get(id);

            if (contrato == null)
                throw new ArgumentException("Id {0} de ContratoVendaMestre não encontrado.");

            var query = _repoContract.AsQueryable()
                                .Include("ProductGroup")
                                .Include("ClientGroup")
                                .Include("PaymentTerm")
                                .Where(x => x.ContratoMestreId == id)
                                .OrderByDescending(x => x.Id);          

            var model = EditContratoVendaMestreModel.CreateAsync(contrato, 
                                query.AsNoTracking(), pageNumber ?? 1, _pageSize);

            return View("Edit", await model);
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