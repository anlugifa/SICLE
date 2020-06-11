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

namespace Sicle.Web.Controllers
{
    [Area("Contratos")]
    public class ContratoVendaMIController : SicleController
    {       

        public ContratoVendaMIController() : base()
        {
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
            var query = new ContratoVendaBus().Query();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Nickname.Contains(searchString)
                                       || s.Observation.Contains(searchString));
            }

            if (status != null)
            {
                //query = query.Where(s => s.Contratos.Any(x => x.Status == status));
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

            return View(await IndexContratoVendaMIVM
                        .CreateAsync(query.AsNoTracking(), pageNumber ?? 1));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id, string sortOrder, int? pageNumber)
        {
            var contrato = new ContratoVendaBus().AsQueryable()
                            .Include(p => p.ContratoMestre)
                            .Include(p => p.PaymentTerm)
                            .Include(p => p.ClientGroup)
                            .Include(p => p.ProductGroup)
                            .Include(p => p.Broker)
                            .Include(p => p.Trader)
                            .Include(p => p.Quotas)
                                .ThenInclude(q => q.Origem)
                            .Include(p => p.Quotas)
                                .ThenInclude(q => q.Destino) 
                            .Include(p => p.PricingPeriods)
                                .ThenInclude(p => p.MapPricingRules)
                            .Include(p => p.PricingRules)
                            .FirstOrDefault(x => x.Id == id);

            if (contrato == null)
                throw new ArgumentException("Id {0} de ContratoVenda não encontrado.");
            
            var vm = new EditContratoVendaVM(contrato);
            vm.ProductGroups = await new ProductGroupBus().GetAllAsync();
            vm.Quotas = contrato.Quotas;

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

            return View("Edit", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int id)
        {
            await new ContratoVendaBus().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View(new ContratoVenda());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(ContratoVenda modelo)
        {
            if (ValidateModel())
            {
                await new ContratoVendaBus().SaveOrUpdate(modelo);
            }

            ViewBag.SuccessMsg = "Contrato salvo com sucesso!";
            return View(modelo);
        }

        public JsonResult GetClientGroupList(string name)
        {
            var repo = new ClientGroupBus();
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name))
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetPaymentTermList(string name)
        {
            var repo = new PaymentTermBus();
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name) && x.IsActive)
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetBrokerList(string name)
        {
            var repo = new BrokerBus();
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name))
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetTraderList(string name)
        {
            var repo = new UsuarioBus();
            var list = repo.AsQueryable()
                            .Where(x => x.Nome.StartsWith(name))
                                .OrderBy(x => x.Nome)
                                .Take(10).ToList();

            return Json(list);
        }       
    }
}

