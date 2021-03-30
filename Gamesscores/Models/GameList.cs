using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Models
{
    public class GameList
    {
        public int Id { get; set; }

        public int Releaseyear { get; set; }

        public string Gamename { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public string ImageUrl { get; set; }

        public IList<Highscore> Highscores { get; set; }
    }
}
