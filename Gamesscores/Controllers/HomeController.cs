using Gamesscores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHighscoreRepository _highscoreRepository;

        public HomeController(IHighscoreRepository highscoreRepository)
        {
            _highscoreRepository = highscoreRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            var model = _highscoreRepository.GetAllHighscores();
            return View(model);            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
