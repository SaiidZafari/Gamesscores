﻿using Gamesscores.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Controllers
{
    public class HighscoresController : Controller
    {
        private IHighscoreRepository _highscoreRepository;

        public HighscoresController(IHighscoreRepository highscoreRepository)
        {
            _highscoreRepository = highscoreRepository;
        }


        public IActionResult Tetris()
        {
            var model = _highscoreRepository.GetAllHighscores();
            return View(model);
        }

        public IActionResult Pacman()
        {
            var model = _highscoreRepository.GetAllHighscores();
            return View(model);
        }

        public IActionResult Donkey_Kong()
        {
            var model = _highscoreRepository.GetAllHighscores();
            return View(model);
        }

        public IActionResult Asteroids()
        {
            var model = _highscoreRepository.GetAllHighscores();
            return View(model);
        }

        public IActionResult New()
        {

            return View();
        }


        [HttpPost]   //Using IActionResult is due to both View and RedirectToAction can used them
        public IActionResult New(Highscore model)
        {
            if (ModelState.IsValid)
            {
                Highscore highscore = new Highscore
                {
                    Score = model.Score,
                    Game = model.Game,
                    Fullname = model.Fullname,
                    Date = model.Date
                };

                _highscoreRepository.Add(highscore);
                return RedirectToAction(highscore.Game, new { id = highscore.Id });
            }

            return View();  //if not succes then back to same page
        }
    }
}
