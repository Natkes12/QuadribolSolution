using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class JogoController : Controller
    {

        private IJogoService _jogoService;

        public JogoController(IJogoService jogo)
        {
            this._jogoService = jogo;
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
        public async Task<IActionResult> Cadastrar(JogoInsertViewModel viewModel)
        {
            return View();
        }
    }
}