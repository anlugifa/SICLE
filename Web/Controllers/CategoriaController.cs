using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoriaController : SicleController
    { 
        public CategoriaController(ApplicationDBContext context) : base(context)
        {

        }


        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        // Nova Categoria
        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.First(c => c.Id == id);
            return View("Salvar", categoria);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int id)
        {
            var categoria = _context.Categorias.First(c => c.Id == id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(Categoria modelo)
        {
            if (ModelState.IsValid)
            {
                if (modelo.Id == 0)
                {
                    _context.Categorias.Add(modelo);
                }
                else
                {
                    var _categoriaFromDB = _context.Categorias.First(c => c.Id == modelo.Id);
                    _categoriaFromDB.Name = modelo.Name;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}