using Gamesscores.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IHighscoreRepository _highscoreRepository;

        public AdminsController(IHighscoreRepository highscoreRepository)
        {
            _highscoreRepository = highscoreRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
