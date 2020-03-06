using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class CompetidorController : Controller
    {
        private ICompetidorService _competidorService;

        public CompetidorController(ICompetidorService competidor)
        {
            this._competidorService = competidor;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CompetidorInsertViewModel viewModel)
        {
            return View();
        }
    }
}