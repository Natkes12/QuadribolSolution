using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuadribolPresentationLayer.Controllers
{
    public class ValidaAcessoController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = this.Request.Cookies["USERIDENTITY"];

            _url = filterContext.HttpContext.Request.Path;

            if (cookie == null)
            {
                filterContext.Result = new RedirectResult(Url.Action("Login", "Usuario"));
            }
            else
            {
                if (!cookie.Contains("ADMIN"))
                {
                    if (_url.ToUpper().Contains("CADASTRAR"))
                    {
                        filterContext.Result = new RedirectResult(Url.Action("Index", "Jogo"));
                    }
                }
            }

            base.OnActionExecuting(filterContext);

        }
    }
}