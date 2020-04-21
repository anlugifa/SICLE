using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using Dados.Repository;
using Dominio.Entidades.Contrato;
using Sicle.Web.Areas.Contratos.Models;
using System.Linq;
using Newtonsoft.Json;

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
            var contrato = _repo.Get(id);

            if (contrato == null)
                throw new ArgumentException("Id {0} de ContratoVenda não encontrado.");
            
            var vm = new EditContratoVendaVM(contrato);
            vm.ProductGroups = await new ProductGroupRepository(_context).GetAllAsync();
            vm.PaymentTerms = await new PaymentTermRepository(_context).GetAllAsync();
            
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

        public JsonResult GetPaymentTermList(string name)
        {
            var repo = new PaymentTermRepository(_context);
            var list = repo.AsQueryable().Where(x => x.Code.StartsWith(name) && x.IsActive)
                                .OrderBy(x => x.Code).Take(10).ToList();

            return Json(list);

        }
    }
}

