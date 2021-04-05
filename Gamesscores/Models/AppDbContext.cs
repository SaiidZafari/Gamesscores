using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gamesscores.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Highscore> Highscores { get; set; }

        public DbSet<GameList> gameLists { get; set; }
        public IEnumerable<Highscore> GameLists { get; internal set; }
    }
}
