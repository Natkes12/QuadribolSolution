using System;
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
    public class TimeController : Controller
    {
        private ITimeService _timeService;
        private ITimeCompetidorService _timeCompetidorService;
        private ICompetidorRepository _competidorRepository;
        private ITimeRepository _timeRepository;
        private IUsuarioService _usuarioService;
        private static Casa _casa;

        public TimeController(ITimeCompetidorService timeCompetidor, ITimeService time, ICompetidorRepository competidor, IUsuarioService usuario, ITimeRepository timeRepo)
        {
            this._timeService = time;
            _timeCompetidorService = timeCompetidor;
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
                List<TimeQueryViewModel> dados = mapper.Map<List<TimeQueryViewModel>>(times.Data);

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

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TimeInsertViewModel, Time>();
            });
            IMapper mapper = configuration.CreateMapper();
            Time time = mapper.Map<Time>(viewModel);

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
        public async Task<IActionResult> Cadastrar(TimeInsertViewModel viewModel)
        {
            List<Competidor> competidores = new List<Competidor>();
            Competidor Artilheiro1 = new Competidor();
            Artilheiro1.Nome = "Batata";
            Artilheiro1.Casa = Casa.Grifinoria;
            Artilheiro1.Escolaridade = Escolaridade.Sexto;
            Artilheiro1.Funcao = Funcao.Artilheiro;
            competidores.Add(Artilheiro1);
            //competidores.Add(viewModel.Artilheiro2);
            //competidores.Add(viewModel.Artilheiro3);
            //competidores.Add(viewModel.Batedor1);
            //competidores.Add(viewModel.Batedor2);
            //competidores.Add(viewModel.Apanhador);
            //competidores.Add(viewModel.Goleiro);

            Time time = new Time();
            time.Competidores = competidores;
            time.Casa = _casa;

            //tempTimeCompetidor.Time = time;

            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<List<TimeCompetidorInsertViewModel>, List<TimeCompetidor>>();
            //});
            //IMapper mapper = configuration.CreateMapper();
            //List<TimeCompetidor> timeCompetidor = mapper.Map<List<TimeCompetidor>>(viewModel);

            try
            {
                await this._timeService.Insert(time);
                return RedirectToAction("Index", "Time");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
                return View();
            }


        }
    }
}