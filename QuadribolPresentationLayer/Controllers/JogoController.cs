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

        public JogoController(IJogoService jogo, ITimeRepository time, INarradorRepository narrador)
        {
            this._jogoService = jogo;
            this._timeRepository = time;
            this._narradorRepository = narrador;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            DataResponse<Time> times = await _timeRepository.GetTimes();
            DataResponse<Narrador> narradores = await _narradorRepository.GetNarradores();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Time, TimeQueryViewModel>();
                cfg.CreateMap<Narrador, NarradorQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<TimeQueryViewModel> dadosTime = mapper.Map<List<TimeQueryViewModel>>(times.Data);
            List<TimeQueryViewModel> dadosNarrador = mapper.Map<List<TimeQueryViewModel>>(narradores.Data);

            ViewBag.Times = dadosTime;
            ViewBag.Narradores = dadosNarrador;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(JogoInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JogoInsertViewModel, Jogo>();
            });
            IMapper mapper = configuration.CreateMapper();
            Jogo jogo = mapper.Map<Jogo>(viewModel);

            try
            {
                await this._jogoService.Insert(jogo);
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