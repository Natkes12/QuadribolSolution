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

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                Usuario usuario = await _usuarioService.Autenticar(email, senha);
                Response.Cookies.Append("USERIDENTITY", usuario.ID.ToString());
                var X = Request.Cookies["USERIDENTITY"].ToString();
                if (usuario.Permissao == Entity.Enums.Permissao.Administrador)
                {
                    return RedirectToAction("Cadastro", "Jogo");
                }
                else
                {
                    return RedirectToAction("Index", "Jogo");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioInsertViewModel, Usuario>();
            });
            IMapper mapper = configuration.CreateMapper();
            Usuario usuario = mapper.Map<Usuario>(viewModel);

            try
            {
                await this._usuarioService.Insert(usuario);
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            return View();
        }
    }
}