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
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";

            return View();
        }
    }
}
