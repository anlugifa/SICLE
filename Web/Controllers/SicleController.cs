using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using log4net;

namespace Web.Controllers
{
    public abstract class SicleController : Controller
    {   
        protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SicleController));

        protected readonly ApplicationDBContext _context;

        protected const int _pageSize = 20;

        public SicleController(ApplicationDBContext context)
        {            
            _context = context;            
        }
    }
}