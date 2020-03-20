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

            _url = filterContext.HttpContext.Request.Path;

            if (cookie != null)
            {
                if (!cookie.Contains("ADMIN"))
                {
                    filterContext.Result = new RedirectResult(Url.Action("Index", "Jogo"));
                }
            }

            base.OnActionExecuting(filterContext);

        }
    }
}