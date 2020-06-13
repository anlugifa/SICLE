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
using Sicle.Business.Admin;
using Sicle.Logs.Utils;

namespace Sicle.Web.Controllers
{
    public abstract class SicleController : Controller
    {
        protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SicleController));

        public Usuario CurrentUser { get; set; }

        public SicleController()
        {   
            SessionVariables.UserId = 259051;
            SessionVariables.UserCode = "CS259051";

            CurrentUser = new UsuarioBus().Get(259051);
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