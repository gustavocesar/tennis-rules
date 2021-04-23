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
    public class GamesController : Controller
    {
        private readonly IGameApplicationService _applicationService;

        public GamesController(IGameApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Games";
            ViewBag.Games = _applicationService.GetGames();

            return View();
        }

        public IActionResult NewGame()
        {
            ViewBag.Games = _applicationService.Create();

            return Redirect("Index");
        }

        public IActionResult Pontuar(int gameId, int jogadorId)
        {
            _applicationService.Pontuar(gameId, jogadorId);
            
            return Redirect("Index");
        }
    }
}
