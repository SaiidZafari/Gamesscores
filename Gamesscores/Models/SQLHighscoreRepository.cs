using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Models
{
    public class SQLHighscoreRepository : IHighscoreRepository
    {
        private readonly AppDbContext context;

        public SQLHighscoreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Highscore Add(Highscore highscore)
        {
            context.Highscores.Add(highscore);
            context.SaveChanges();
            return highscore;
        }

        public Highscore Delete(int Id)
        {
            Highscore highscore = context.Highscores.Find(Id);
            if (highscore != null)
            {
                context.Highscores.Remove(highscore);
                context.SaveChanges();
            }
            return highscore;
        }

        public IEnumerable<Highscore> GetAllHighscores()
        {
            return context.Highscores;
        }

        public Highscore GetHighscore(int Id)
        {
            return context.Highscores.Find(Id);
        }

        public Highscore Update(Highscore highscoreChanges)
        {
            var highscore = context.Highscores.Attach(highscoreChanges);
            highscore.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return highscoreChanges;
        }
    }
}
