﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAO.Interfaces;
using Entity;
using Entity.Enums;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;
using QuadribolPresentationLayer.Models.Query;

namespace QuadribolPresentationLayer.Controllers
{
    public class TimeController : ValidaAcessoController
    {
        private ITimeService _timeService;
        private ICompetidorRepository _competidorRepository;
        private ITimeRepository _timeRepository;
        private IUsuarioService _usuarioService;
        private static Casa _casa;

        public TimeController(ITimeService time, ICompetidorRepository competidor, IUsuarioService usuario, ITimeRepository timeRepo)
        {
            this._timeService = time;
            this._competidorRepository = competidor;
            this._timeRepository = timeRepo;
            this._usuarioService = usuario;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<Time> times = await _timeRepository.GetTimes();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Time, TimeQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();
                List<TimeQueryViewModel> dados = mapper.Map<List<TimeQueryViewModel>>(times.Data.Result);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }

        }

        public async Task<IActionResult> FiltrarCasa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FiltrarCasa(TimeInsertViewModel viewModel)
        {
            _casa = viewModel.Casa;

            switch (viewModel.Casa)
            {
                case Casa.Grifinoria:
                    viewModel.CaminhoImagem = "https://img.elo7.com.br/product/original/2A97806/patch-bordado-brasao-grifinoria-harry-potter-modelo2.jpg";
                    break;
                case Casa.Sonserina:
                    viewModel.CaminhoImagem = "https://img.elo7.com.br/product/original/2A977DE/patch-bordado-brasao-sonserina-harry-potter-modelo2.jpg";
                    break;
                case Casa.Corvinal:
                    viewModel.CaminhoImagem = "https://img.elo7.com.br/product/zoom/2A977D3/patch-bordado-brasao-corvinal-harry-potter-modelo2.jpg";
                    break;
                case Casa.Lufa_Lufa:
                    viewModel.CaminhoImagem = "https://img.elo7.com.br/product/original/2A977F7/patch-bordado-brasao-lufa-lufa-harry-potter-modelo2.jpg";
                    break;
                default:
                    break;
            }

            ViewBag.Errors = null;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TimeInsertViewModel, Time>();
            });
            IMapper mapper = configuration.CreateMapper();
            Time time = mapper.Map<Time>(viewModel);

            Time timeTemp = await this._timeRepository.GetByCasa(time.Casa);

            if (timeTemp != null)
            {
                List<Competidor> competidores = await this._competidorRepository.GetCompetidores().Result.Data;
                foreach (var item in competidores)
                {
                    if (item.Casa == timeTemp.Casa)
                    {
                        await this._competidorRepository.DesalocarTime(item);
                    }
                }
                return RedirectToAction("Cadastrar", "Time");
            }

            try
            {
                await this._timeService.Insert(time);
                return RedirectToAction("Cadastrar", "Time");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
                return View();
            }

        }

        public async Task<IActionResult> Cadastrar()
        {
            List<Competidor> competidores = await _competidorRepository.GetCompetidores().Result.Data;
            List<Time> times = await _timeRepository.GetTimes().Result.Data;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Competidor, CompetidorQueryViewModel>();
                cfg.CreateMap<Time, TimeQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<TimeQueryViewModel> dadosTimes = mapper.Map<List<TimeQueryViewModel>>(times);
            List<CompetidorQueryViewModel> dadosCompetidores = mapper.Map<List<CompetidorQueryViewModel>>(competidores);

            ViewBag.Competidores = competidores;
            ViewBag.Time = dadosTimes;
            ViewBag.Casa = _casa;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(List<int> viewModel)
        {
            Competidor competidorTemp = new Competidor();
            Time time = await this._timeRepository.GetByCasa(_casa);

            foreach (var item in viewModel)
            {
                competidorTemp = await _competidorRepository.GetByID(item);
                competidorTemp.Time = time;
                competidorTemp.TimeID = time.ID;
                await this._competidorRepository.Update(competidorTemp);
            }

            return RedirectToAction("Index", "Time");

        }
    }
}