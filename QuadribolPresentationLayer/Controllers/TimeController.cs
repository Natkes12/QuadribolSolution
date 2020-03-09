﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuadribolPresentationLayer.Models.Insert;

namespace QuadribolPresentationLayer.Controllers
{
    public class TimeController : Controller
    {
        private ITimeService _timeService;

        public TimeController(ITimeService time)
        {
            this._timeService = time;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(TimeInsertViewModel viewModel)
        {
            return View();
        }
    }
}