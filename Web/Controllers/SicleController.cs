using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using log4net;
using System.Text;
using System;

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

        public bool ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                var sb = new StringBuilder();
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                }

                var str = sb.ToString();
                _log.Info(str);

                ViewBag.Msg = str;

                return false;
            }

            return true;
        }
    }
}