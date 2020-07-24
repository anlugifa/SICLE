using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades.Contrato;
using Sicle.Web.Areas.Contratos.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Sicle.Business.Contratos;
using Sicle.Business.Admin;
using System.Collections.Generic;
using Dominio.Entidades.Produtos;
using Sicle.Logs.Utils;
using Sicle.Web.Models;

namespace Sicle.Web.Controllers
{
    [Area("Contratos")]
    public class ContratoVendaMIController : SicleController
    {       

        public ContratoVendaMIController() : base()
        {
        }               

        public async Task<IActionResult> Index(IndexContratoVendaFilter filter)
        {   
            #region filter
            
            filter.SetViewData(ViewData);

            var query = new EvaluatedContractBus().AsQueryable();
            query = filter.DoFilter<EvaluatedSaleContract>(query);
            var evaluatedList = query.AsNoTracking().ToList();

            var query2 = new ApprovalContractBus().AsQueryable();
            query2 = filter.DoFilter<ApprovalSaleContract>(query2);
            var approvedList = query2.AsNoTracking().ToList();
            #endregion

            var list = new List<SaleContract>();
            foreach(var eval in evaluatedList)
            {
                bool includEval = true;
                foreach(var app in approvedList)
                {
                    if (app.EvaluatedContractId == eval.Id)
                    {
                        includEval = false;
                        break;
                    }
                }

                if(includEval)
                    list.Add(eval);
            }

            var finalList = new List<SaleContract>( approvedList.Concat(list) );           
            
            var vm = IndexContratoVendaMIVM<SaleContract>.CreateAsync(finalList, filter.PageNumber ?? 1);
            vm.ProductGroups = await new ProductGroupBus().GetAllAsync();
            vm.Filter = filter;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id, string sortOrder, int? pageNumber)
        {
            SaleContract contrato;
            if (id == 0) // novo
            {
                contrato = new ApprovalSaleContract()
                {
                    CreationDate = DateTime.Now,
                    CreationUserId = SessionVariables.UserId
                };         
            }
            else 
            {
                contrato = LoadContrato(id);

                if (contrato == null)
                    throw new ArgumentException("Id {0} de ContratoVenda não encontrado.");
            }

            // var vm = new EditContratoVendaVM(contrato);                  

            // var quotas = from q in _context.SaleContractQuotas
            //         join o in _context.Localidades on q.OrigemId equals o.Id into origem
            //         join c in _context.Clients on q.DestinoId equals c.Id into destino
            //         where q.ContratoId == id
            //         orderby q.Id descending
            //         select new SaleContractQuota{
            //             Id = q.Id,
            //             QuotaVolume = q.QuotaVolume,
            //             TotalVolume = q.TotalVolume,
            //             Diflog = q.Diflog,
            //             Freight = q.Freight,
            //             Type = q.Type,

            //             Origem = origem.FirstOrDefault(),
            //             Destino = destino.FirstOrDefault()
            //         };
            // vm.Quotas = quotas.ToList();

            // vm.Quotas = await new SaleContractQuotaRepositoy(_context)
            //                 .AsQueryable()
            //                 .Where( x => x.ContratoId == id)
            //                 .Include(p => p.Origem)
            //                 .Include(p => p.Destino)
            //                 .OrderByDescending(x => x.Id)
            //                 .ToListAsync();

            return View("Edit", contrato);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            await new ContratoVendaBus<SaleContract>().Delete(id);
            return RedirectToAction("Index");
        }      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SaleContract contrato)
        {
            if (ValidateModel())
            {
                await new ContratoVendaBus<SaleContract>().SaveOrUpdate(contrato);
                ViewBag.SuccessMsg = "Contrato salvo com sucesso!";
            }

            return View("Edit", contrato);
        }

        public static IEnumerable<ProductGroup> ListProductGroups()
        {
            return new ProductGroupBus().GetAll();  
        }

        public SaleContract LoadContrato(long id)
        {
            return new ContratoVendaBus<SaleContract>().AsQueryable()
                                .Include(p => p.ContratoMestre)
                                .Include(p => p.PaymentTerm)
                                .Include(p => p.ClientGroup)
                                .Include(p => p.ProductGroup)
                                .Include(p => p.Broker)
                                .Include(p => p.Trader)
                                .Include(p => p.CreationUser)
                                .Include(p => p.Editor)
                                .Include(p => p.Quotas)
                                    .ThenInclude(q => q.Origem)
                                .Include(p => p.Quotas)
                                    .ThenInclude(q => q.Destino) 
                                .Include(p => p.PricingPeriods)
                                    .ThenInclude(p => p.MapPricingRules)
                                .Include(p => p.PricingRules)
                                .FirstOrDefault(x => x.Id == id);
        }

        public JsonResult GetMasterList(string name)
        {
            var repo = new MasterSaleContractBus();
            var list = repo.AsQueryable().Where(x => x.Nickname.Contains(name))
                                .OrderBy(x => x.Nickname).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetClientGroupList(string name)
        {
            var repo = new ClientGroupBus();
            var list = repo.AsQueryable().Where(x => x.Code.Contains(name))
                                .OrderBy(x => x.Code).Take(10).ToList().Select(o => new ClientGroup()
                                {
                                    Id = o.Id, 
                                    Code = o.ToString()
                                });

            return Json(list);
        }

        public JsonResult GetPaymentTermList(string name)
        {
            var repo = new PaymentTermBus();
            var list = repo.AsQueryable().Where(x => x.Code.Contains(name) && x.IsActive)
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetBrokerList(string name)
        {
            var repo = new BrokerBus();
            var list = repo.AsQueryable().Where(x => x.Code.Contains(name))
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetTraderList(string name)
        {
            var repo = new UsuarioBus();
            var list = repo.AsQueryable()
                            .Where(x => x.Nome.Contains(name))
                                .OrderBy(x => x.Nome)
                                .Take(10).ToList();

            return Json(list);
        }       
    }
}

