using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class CompetidorController : Controller
    {

        

        private ICompetidorService _competidorService;
        private IUsuarioService _usuarioService;

        public CompetidorController(ICompetidorService competidor, IUsuarioService usuario)
        {
            this._competidorService = competidor;
            this._usuarioService = usuario;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            int usuarioId = Convert.ToInt32(Request.Cookies["USERIDENTITY"].ToString());
            var usuario = _usuarioService.GetUsuario(usuarioId);

            if (usuario.Result.Permissao != Entity.Enums.Permissao.Administrador)
            {
                return RedirectToAction("Index", "Jogo");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CompetidorInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompetidorInsertViewModel, Competidor>();
            });
            IMapper mapper = configuration.CreateMapper();
            Competidor competidor = mapper.Map<Competidor>(viewModel);

            try
            {
                await this._competidorService.Insert(competidor);
                return RedirectToAction("Cadastrar", "Time");
            }
            catch(Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            return View();
        }
    }
}