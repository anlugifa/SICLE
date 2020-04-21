using System;
using System.Threading.Tasks;
using Dados;
using Microsoft.AspNetCore.Mvc;
using Dados.Repository;
using Dominio.Entidades.Contrato;

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
        public IActionResult Editar(long id, string sortOrder, int? pageNumber)
        {
            var contrato = _repo.Get(id);

            if (contrato == null)
                throw new ArgumentException("Id {0} de ContratoVenda não encontrado.");

            var model = _repo.Get(id);

            return View("Edit", model);
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
    }
}

