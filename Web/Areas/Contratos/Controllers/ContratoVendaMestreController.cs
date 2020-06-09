using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sicle.Web.Models;
using Dominio.Entidades.Acesso;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Dominio.Entidades.Contrato;
using Sicle.Web.Areas.Contratos.Models;
using Sicle.Web.Util;
using Sicle.Business.Contratos;

namespace Sicle.Web.Controllers
{
    [Area("Contratos")]
    public class ContratoVendaMestreController : SicleController
    {
        private readonly ContratoVendaMestreBus _repo;
        private readonly ContratoVendaBus _repoContract;

        public ContratoVendaMestreController() : base()
        {
            _repo = new ContratoVendaMestreBus();
            _repoContract = new ContratoVendaBus();
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

            if (status != null)
            {
                query = query.Where(s => s.Contratos.Any(x => x.Status == status));
            }
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

            return View(await IndexContratoVendaMestreVM
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1));
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id, string sortOrder, int? pageNumber)
        {
            var contrato = _repo.AsQueryable().Include(p => p.Contratos).FirstOrDefault(p => p.Id == id);

            if (contrato == null)
                throw new ArgumentException("Id {0} de ContratoVendaMestre não encontrado.");

            var contratos = _repoContract.AsQueryable()
                                .Include(p => p.ProductGroup)
                                .Include(p => p.ClientGroup)
                                .Include(p => p.PaymentTerm)
                                .Where(x => x.ContratoMestreId == id)
                                .OrderByDescending(x => x.Id);          

            var model = ContratoVendaMestreVM.CreateAsync(contrato, 
                                contratos.AsNoTracking(), pageNumber ?? 1);

            return View("Details", await model);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int id)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            ContratoVendaMestreModel model = null;

            if (id > 0)
            {                
                var mestre = LoadMestre(id);
                if (mestre != null)
                {
                    model = new ContratoVendaMestreModel(mestre);
                }
                else
                {
                    AddError("Contrato {0} não encontrado", id);
                }
            }
            
            if (model == null)
            {
                model = new ContratoVendaMestreModel()
                {
                    IsActive = true,
                    CreationDate = DateTime.Today,
                    CreationUserId = CurrentUser.Id,
                    CreationUser = CurrentUser 
                };
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContratoVendaMestreModel model)
        {
            if (ValidateModel())
            {
                var contrato = (ContratoVendaMestre)model;
                await _repo.SaveOrUpdate(contrato);

                if (contrato.Id > 0) {

                    // restore from db by new Id
                    model = new ContratoVendaMestreModel(LoadMestre(contrato.Id));

                    AddSuccess("Contrato salvo com sucesso!");
                }
            }
            
            return RedirectToAction("Edit", model.Id);
        }

        internal ContratoVendaMestre LoadMestre(long id)
        {
            return _repo.AsQueryable().Include(p => p.CreationUser).FirstOrDefault(p => p.Id == id);
        }
    }
}