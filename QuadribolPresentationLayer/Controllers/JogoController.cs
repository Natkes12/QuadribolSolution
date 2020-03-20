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
    public class JogoController : ValidaAcessoController
    {

        private IJogoService _jogoService;
        private IJogoRepository _jogoRepository;
        private ITimeRepository _timeRepository;
        private INarradorRepository _narradorRepository;
        private IUsuarioService _usuarioService;
        private IJogoTimeRepository _jogoTimeRepository;
        private IJogoTimeService _jogoTimeService;

        public JogoController(IJogoRepository jogoRepository, IJogoTimeService jogoTimeService, IJogoTimeRepository jogoTime, IJogoService jogo, ITimeRepository time, INarradorRepository narrador, IUsuarioService usuairo)
        {
            this._jogoService = jogo;
            this._timeRepository = time;
            this._narradorRepository = narrador;
            this._usuarioService = usuairo;
            this._jogoTimeRepository = jogoTime;
            this._jogoTimeService = jogoTimeService;
            this._jogoRepository = jogoRepository;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<Jogo> jogos = await _jogoService.GetJogos();
                List<JogoTime> response = new List<JogoTime>();

                foreach (var item in jogos.Data.Result)
                {
                    foreach (var item2 in item.JogosTime)
                    {
                        response.Add(item2);
                    }
                }

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<JogoTime, JogoQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();

                List<JogoQueryViewModel> dados = mapper.Map<List<JogoQueryViewModel>>(response);

                return View(dados);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Cadastrar()
        {
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
        public async Task<IActionResult> Cadastrar(JogoInsertViewModel viewModel, List<int> Times)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JogoInsertViewModel, Jogo>();
            });
            IMapper mapper = configuration.CreateMapper();
            Jogo jogo = mapper.Map<Jogo>(viewModel);

            try
            {
                await this._jogoRepository.Insert(jogo);

                int jogoID = await this._jogoRepository.GetJogoID(jogo);

                foreach (var item in Times)
                {
                    await this._jogoTimeRepository.Insert(jogoID, item);
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