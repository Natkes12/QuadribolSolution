using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class UsuarioController : Controller
    {

        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuario)
        {
            this._usuarioService = usuario;
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
        public async Task<IActionResult> Cadastrar(UsuarioInsertViewModel viewModel)
        {
            return View();
        }
    }
}