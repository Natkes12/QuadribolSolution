using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Entity;
using Entity.Enums;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;
using QuadribolPresentationLayer.Models.Query;

namespace QuadribolPresentationLayer.Controllers
{
    public class UsuarioController : UsuarioBaseController
    {

        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuario)
        {
            this._usuarioService = usuario;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<Usuario> usuarios = await _usuarioService.GetUsuarios();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuario, UsuarioQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();

                List<UsuarioQueryViewModel> dados = mapper.Map<List<UsuarioQueryViewModel>>(usuarios.Data.Result);

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

                if (usuario == null)
                {
                    ViewBag.InvalidLogin = "Email e/ou Senha inválido(s).";
                    return View();
                }
                else
                {
                    ViewBag.InvalidLogin = "";
                }

                if (usuario.Permissao == Permissao.Administrador)
                {
                    Response.Cookies.Append("USERIDENTITY", usuario.ID.ToString()+"ADMIN");
                }
                else
                {
                    Response.Cookies.Append("USERIDENTITY", usuario.ID.ToString());
                }

                return Redirect(_url);

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

            usuario.EhAtivo = true;
            usuario.Permissao = Permissao.Normal;

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

        public async Task<IActionResult> AlterarUsuario()
        {
            List<Usuario> usuarios = await this._usuarioService.GetUsuarios().Result.Data;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<UsuarioQueryViewModel> dados = mapper.Map<List<UsuarioQueryViewModel>>(usuarios);

            ViewBag.Usuarios = dados;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AlterarUsuario(int usuarioID, UsuarioInsertViewModel viewModel)
        {
            Usuario usuario = await this._usuarioService.GetUsuario(usuarioID);

            usuario.Permissao = viewModel.Permissao;

            try
            {
                await this._usuarioService.Update(usuario);
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            return View();

        }

        public async Task<IActionResult> DeletarUsuario()
        {
            List<Usuario> usuarios = await this._usuarioService.GetUsuarios().Result.Data;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<UsuarioQueryViewModel> dados = mapper.Map<List<UsuarioQueryViewModel>>(usuarios);

            ViewBag.Usuarios = dados;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeletarUsuario(int usuarioID)
        {
            Usuario usuario = await this._usuarioService.GetUsuario(usuarioID);

            try
            {
                await this._usuarioService.Delete(usuario);
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            return View();
        }

        public async Task<IActionResult> Sair()
        {
            Response.Cookies.Delete("USERIDENTITY");

            return RedirectToAction("Login", "Usuario");
        }

        public async Task<IActionResult> CadastrarTemporario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTemporario(UsuarioInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioInsertViewModel, Usuario>();
            });
            IMapper mapper = configuration.CreateMapper();
            Usuario usuario = mapper.Map<Usuario>(viewModel);

            usuario.EhAtivo = true;

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