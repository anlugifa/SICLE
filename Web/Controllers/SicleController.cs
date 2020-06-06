using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using log4net;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using Sicle.Web.Util;
using Dominio.Entidades.Acesso;
using Dados.Repository;

namespace Sicle.Web.Controllers
{
    public abstract class SicleController : Controller
    {
        protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SicleController));

        protected readonly ApplicationDBContext _context;

        public Usuario CurrentUser { get; set; }

        public SicleController(ApplicationDBContext context)
        {
            _context = context;

            SessionVariables.UserId = 259051;
            CurrentUser = new UsuarioRepository(context).Get(259051);
        }

        public void AddError(string error, params object[] args)
        {
            ViewBag.ErrorMsg += String.Format(error, args);
        }

        public void AddSuccess(string msg, params object[] args)
        {
            ViewBag.SuccessMsg += String.Format(msg, args);        
        }

        public bool ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                var sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        sb.AppendLine("<li>" + error.ErrorMessage + "</li>");
                        sb.Append(Environment.NewLine);
                    }
                }
                sb.AppendLine("</ul>");

                var str = sb.ToString();
                _log.Info(str);

                ViewBag.ErrorMsg = str;

                return false;
            }

            return true;
        }
    }
}