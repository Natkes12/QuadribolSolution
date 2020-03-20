using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuadribolPresentationLayer.Controllers
{
    public class BaseController : Controller
    {
        protected static string _url;
    }
}