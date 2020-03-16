using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DAO.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;
using QuadribolPresentationLayer.Models.Query;

namespace QuadribolPresentationLayer.Controllers
{
    public class JogoController : Controller
    {

        private IJogoService _jogoService;
        private ITimeRepository _timeRepository;
        private INarradorRepository _narradorRepository;
        private IUsuarioService _usuarioService;
        private IJogoTimeRepository _jogoTimeRepository;
        private IJogoTimeService _jogoTimeService;

        public JogoController(IJogoTimeService jogoTimeService, IJogoTimeRepository jogoTime, IJogoService jogo, ITimeRepository time, INarradorRepository narrador, IUsuarioService usuairo)
        {
            this._jogoService = jogo;
            this._timeRepository = time;
            this._narradorRepository = narrador;
            this._usuarioService = usuairo;
            this._jogoTimeRepository = jogoTime;
            this._jogoTimeService = jogoTimeService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<Jogo> jogos = await _jogoService.GetJogos();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Jogo, JogoQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();

                List<JogoQueryViewModel> dados = mapper.Map<List<JogoQueryViewModel>>(jogos.Data);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public async Task<IActionResult> Cadastrar()
        {
            Usuario usuario = new Usuario();

            try
            {
                int usuarioId = Convert.ToInt32(Request.Cookies["USERIDENTITY"].ToString());
                usuario = await _usuarioService.GetUsuario(usuarioId);
            }
            catch (NullReferenceException)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (usuario.Permissao != Entity.Enums.Permissao.Administrador)
            {
                return RedirectToAction("Index", "Jogo");
            }

            List<Time> times = await _timeRepository.GetTimes().Result.Data;
            List<Narrador> narradores = await _narradorRepository.GetNarradores().Result.Data;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Time, TimeQueryViewModel>();
                cfg.CreateMap<Narrador, NarradorQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<TimeQueryViewModel> dadosTime = mapper.Map<List<TimeQueryViewModel>>(times);

            ViewBag.Times = dadosTime;

            List<NarradorQueryViewModel> dadosNarrador = mapper.Map<List<NarradorQueryViewModel>>(narradores);

            ViewBag.Narradores = dadosNarrador;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(List<JogoTimeInsertViewModel> viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<JogoTimeInsertViewModel>, List<JogoTime>>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<JogoTime> jogoTime = mapper.Map<List<JogoTime>>(viewModel);

            try
            {
                foreach (var item in jogoTime)
                {
                    await this._jogoTimeService.Insert(item);
                }
                return RedirectToAction("Index", "Jogo");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            return View();
        }
    }
}