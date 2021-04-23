using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using Application.Services.Contracts;

namespace Presentation.Controllers
{
    public class JogadoresController : Controller
    {
        private readonly IJogadorApplicationService _applicationService;

        public JogadoresController(IJogadorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Jogadores";
            ViewBag.Jogadores = _applicationService.GetJogadores();

            return View();
        }
    }
}
