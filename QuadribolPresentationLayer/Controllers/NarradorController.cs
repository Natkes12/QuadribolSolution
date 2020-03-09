using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class NarradorController : Controller
    {

        private INarradorService _narradorService;

        public NarradorController(INarradorService narrador)
        {
            this._narradorService = narrador;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(NarradorInsertViewModel viewModel)
        {
            return View();
        }
    }
}