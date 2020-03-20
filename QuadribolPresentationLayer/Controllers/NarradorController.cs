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
    public class NarradorController : ValidaAcessoController
    {

        private INarradorService _narradorService;
        private IUsuarioService _usuarioService;

        public NarradorController(INarradorService narrador, IUsuarioService usuario)
        {
            this._narradorService = narrador;
            this._usuarioService = usuario;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                DataResponse<Narrador> narradores = await _narradorService.GetNarrador();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Narrador, NarradorQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();
                List<NarradorQueryViewModel> dados = mapper.Map<List<NarradorQueryViewModel>>(narradores.Data.Result);

                return View(dados);
            }
            catch (Exception)
            {
                return View();
            }

        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(NarradorInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NarradorInsertViewModel, Narrador>();
            });
            IMapper mapper = configuration.CreateMapper();
            Narrador narrador = mapper.Map<Narrador>(viewModel);

            try
            {
                await this._narradorService.Insert(narrador);
                return RedirectToAction("Index", "Competidor");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            return View();
        }
    }
}