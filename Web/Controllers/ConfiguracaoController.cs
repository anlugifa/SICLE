using System;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dados.Repository;
using Dominio.Entidades;
using Dominio.Entidades.Infra;
using Microsoft.AspNetCore.Mvc;
using Sicle.Business.Admin;
using Sicle.Web.Controllers;

namespace Sicle.Web.Controllers
{
    public class ConfiguracaoController : SicleController
    {

        private readonly ConfiguracaoBus _repo;


        public ConfiguracaoController()
        {
            _repo = new ConfiguracaoBus();
        }


        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 50)
        {
            pageIndex = pageIndex > 0 ? pageIndex : 1;
            pageSize  = pageSize  < 1000 ?  pageSize : 1000;

            var items = await _repo.RestorePageAsync(pageIndex, pageSize);
            return View(items);
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            var item = _repo.Get(id);
            return View("Salvar", item);
        }

        [HttpGet]
        public IActionResult Remover(string id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(Configuracao modelo)
        {
            if (ModelState.IsValid)
            {
                await _repo.SaveOrUpdate(modelo);
            }

            return RedirectToAction("Index");
        }
    }
}