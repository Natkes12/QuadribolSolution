using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuadribolPresentationLayer.Controllers
{
    public class UsuarioBaseController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = this.Request.Cookies["USERIDENTITY"];

            string url = filterContext.HttpContext.Request.Path.ToString().ToUpper();

            if (!url.Contains("LOGIN") && !url.Contains("CADASTRAR"))
            {
                if (cookie != null)
                {
                    if (!cookie.Contains("ADMIN") && !url.Contains("SAIR"))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("Index", "Jogo"));
                    }
                }
                else
                {
                    filterContext.Result = new RedirectResult(Url.Action("Login", "Usuario"));
                }
            }
            else if (url.Contains("LOGIN"))
            {
                if (cookie != null)
                {
                    filterContext.Result = new RedirectResult(Url.Action("Index", "Jogo"));
                }
            }

            base.OnActionExecuting(filterContext);

        }
    }
}