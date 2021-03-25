using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Models
{
    public class Highscore
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Fullname { get; set; }

        public string Game { get; set; }

        public DateTime Date { get; set; }
    }
}
