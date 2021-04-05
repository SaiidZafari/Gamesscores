using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Models
{
    public interface IHighscoreRepository
    {
        // This method will get information from database
        Highscore GetHighscore(int Id);
        IEnumerable<Highscore> GetAllHighscores();

        IEnumerable<GameList> GetAllGameLists();

        IEnumerable<string> GetAllGames();

        Highscore Add(Highscore highscore);
        //Highscore Add(RegisterHighscore highscore);

        Highscore Update(Highscore highscoreChange);

        Highscore Delete(int id);
        //void Add(RegisterHighscore newHighscore);
    }
}
