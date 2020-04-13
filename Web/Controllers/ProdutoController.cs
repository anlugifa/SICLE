using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
   public class ProdutoController : Controller
   {       
        private readonly ApplicationDBContext _context;

        public ProdutoController(ApplicationDBContext context)
        {
            _context = context;
        }      
              

        [HttpGet]
        public IActionResult Index()
        {
            var list = _context.Produtos.Include(p => p.Categoria).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Include(p => p.Categoria).First(c => c.Id == id );
            ViewBag.Categorias = _context.Categorias.ToList();

            return View("Salvar", produto);
        }

        [HttpGet]
        public async Task<IActionResult>  Remover(int id)
        {
            var produto = _context.Produtos.First(c => c.Id == id );
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {           
            var list = _context.Categorias.ToList();
            ViewBag.Categorias = list;
            return View(new Produto()
                {
                    CategoriaId = list[0].Id,
                    Categoria = list[0]
                });
        } 


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar(Produto modelo)
        {
            if (!ModelState.IsValid) 
            {
                var sb = new StringBuilder();
                foreach (var modelState in ViewData.ModelState.Values) {
                    foreach (var error in modelState.Errors) {
                        sb.AppendLine(error.ErrorMessage);
                    }
                }

                ViewBag.Msg = sb.ToString();
            } else {
        
                if (modelo.Id == 0) {
                        _context.Produtos.Add(modelo);                    
                } 
                else {
                    var _produtosFromDB = _context.Produtos.First(c => c.Id == modelo.Id );
                    _produtosFromDB.Name = modelo.Name;              
                    _produtosFromDB.CategoriaId = modelo.CategoriaId;   
                }
                await _context.SaveChangesAsync();               
            
            }

            ViewBag.Categorias = _context.Categorias.ToList();
            return View(modelo);
        }       
   }
}