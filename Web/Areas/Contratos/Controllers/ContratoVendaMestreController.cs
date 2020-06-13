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

        public async Task<IActionResult> Index(IndexContratoVendaMestreFilter filter)
        {
            #region filter
            filter.SetViewData(ViewData);

            var query = _repo.AsQueryable().Include("Contratos");
            
            query = filter.DoFilter(query);
            #endregion

            return View(await IndexContratoVendaMestreVM
                        .CreateAsync(query.AsNoTracking(), filter.PageNumber ?? 1));
        }

        [HttpGet]
        public async Task<IActionResult> Details(DetailsContratoVendaMestreFilter filter)//long id, string sortOrder, int? pageNumber)
        {
            var contrato = _repo.AsQueryable().Include(p => p.Contratos).FirstOrDefault(p => p.Id == filter.Id);

            if (contrato == null)
                throw new ArgumentException("Id {0} de ContratoVendaMestre não encontrado.");

            var contratos = _repoContract.AsQueryable()
                                .Include(p => p.ProductGroup)  
                                .Include(p => p.ClientGroup)
                                .Include(p => p.PaymentTerm)
                                .Where(x => x.ContratoMestreId == filter.Id);      

            filter.SetViewData(ViewData);
            contratos = filter.DoFilter(contratos);   

            var model = await DetailsContratoVendaMestreVM.CreateAsync(contrato, 
                                contratos.AsNoTracking(), filter.PageNumber ?? 1);

            return View("Details", model);
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