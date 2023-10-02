using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using RickyAndMorthyApp.Models;
using System;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace RickyAndMorthyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Characters character = new();
            Character info = await character.getCharacter();

            ViewBag.character = info.name;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}