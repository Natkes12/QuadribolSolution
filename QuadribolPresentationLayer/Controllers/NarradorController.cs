using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class NarradorController : Controller
    {

        private INarradorService _narradorService;

        public NarradorController(INarradorService narrador)
        {
            this._narradorService = narrador;
        }

        public IActionResult Index()
        {
            return View();
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