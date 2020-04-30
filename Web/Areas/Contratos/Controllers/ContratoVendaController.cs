using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using Dados.Repository;
using Dominio.Entidades.Contrato;
using Sicle.Web.Areas.Contratos.Models;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Area("Contratos")]
    public class ContratoVendaController : SicleController
    {
        private readonly ContratoVendaRepository _repo;

        public ContratoVendaController(ApplicationDBContext context) : base(context)
        {
            _repo = new ContratoVendaRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(long id, string sortOrder, int? pageNumber)
        {
            var contrato = _context.ContratosVendas
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
            vm.ProductGroups = await new ProductGroupRepository(_context).GetAllAsync();
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
        public IActionResult Remover(int id)
        {
            _repo.Delete(id);
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
                await _repo.SaveOrUpdate(modelo);
            }

            ViewBag.SuccessMsg = "Contrato salvo com sucesso!";
            return View(modelo);
        }

        public JsonResult GetClientGroupList(string name)
        {
            var repo = new ClientGroupRepository(_context);
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name))
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetPaymentTermList(string name)
        {
            var repo = new PaymentTermRepository(_context);
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name) && x.IsActive)
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetBrokerList(string name)
        {
            var repo = new BrokerRepository(_context);
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name))
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);
        }

        public JsonResult GetTraderList(string name)
        {
            var repo = new UsuarioRepository(_context);
            var list = repo.AsQueryable()
                            .Where(x => x.Nome.StartsWith(name))
                                .OrderBy(x => x.Nome)
                                .Take(10).ToList();

            return Json(list);
        }       
    }
}

