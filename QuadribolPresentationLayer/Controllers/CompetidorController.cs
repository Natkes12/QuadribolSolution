using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace QuadribolPresentationLayer.Controllers
{
    public class CompetidorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Cadastrar()
        //{
        //    return View();
        //}
    }
}