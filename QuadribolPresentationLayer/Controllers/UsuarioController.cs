using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;
using QuadribolPresentationLayer.Models.Query;

namespace QuadribolPresentationLayer.Controllers
{
    public class UsuarioController : Controller
    {

        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuario)
        {
            this._usuarioService = usuario;
        }

        public async Task<IActionResult> Index()
        {
            Usuario usuario = new Usuario();

            try
            {
                int usuarioId = Convert.ToInt32(Request.Cookies["USERIDENTITY"].ToString());
                usuario = await _usuarioService.GetUsuario(usuarioId);
            }
            catch (NullReferenceException ex)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (usuario.Permissao != Entity.Enums.Permissao.Administrador)
            {
                return RedirectToAction("Index", "Jogo");
            }

            try
            {
                DataResponse<Usuario> usuarios = await _usuarioService.GetUsuarios();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuario, UsuarioQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();

                List<UsuarioQueryViewModel> dados = mapper.Map<List<UsuarioQueryViewModel>>(usuarios.Data);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }
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
                //var X = Request.Cookies["USERIDENTITY"].ToString();
                if (usuario.Permissao == Entity.Enums.Permissao.Administrador)
                {
                    return RedirectToAction("Cadastrar", "Jogo");
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
            //Usuario usuario = new Usuario();

            //try
            //{
            //    int usuarioId = Convert.ToInt32(Request.Cookies["USERIDENTITY"].ToString());
            //    usuario = await _usuarioService.GetUsuario(usuarioId);
            //}
            //catch (NullReferenceException)
            //{
            //    return RedirectToAction("Login", "Usuario");
            //}

            //if (usuario.Permissao != Entity.Enums.Permissao.Administrador)
            //{
            //    return RedirectToAction("Index", "Jogo");
            //}

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