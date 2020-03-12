﻿using System;
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

        public JogoController(IJogoService jogo, ITimeRepository time, INarradorRepository narrador, IUsuarioService usuairo)
        {
            this._jogoService = jogo;
            this._timeRepository = time;
            this._narradorRepository = narrador;
            this._usuarioService = usuairo;
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

            DataResponse<Time> times = await _timeRepository.GetTimes();
            DataResponse<Narrador> narradores = await _narradorRepository.GetNarradores();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Time, TimeQueryViewModel>();
                cfg.CreateMap<Narrador, NarradorQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<TimeQueryViewModel> dadosTime = mapper.Map<List<TimeQueryViewModel>>(times.Data.Result);

            ViewBag.Times = dadosTime;

            List<NarradorQueryViewModel> dadosNarrador = mapper.Map<List<NarradorQueryViewModel>>(narradores.Data.Result);

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