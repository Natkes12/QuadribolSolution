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
        TimeService service;

        public JogoController(IJogoService jogo, ITimeRepository time)
        {
            this._jogoService = jogo;
            this.service = new TimeService(time);
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            DataResponse<Time> times = await service.GetTimes();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Time, TimeQueryViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            List<TimeQueryViewModel> dados = mapper.Map<List<TimeQueryViewModel>>(times);

            ViewBag.Times = dados;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(JogoInsertViewModel viewModel)
        {
            return View();
        }
    }
}