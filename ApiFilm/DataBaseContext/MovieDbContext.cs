using ApiFilm.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilm.DataBaseContext
{
    public class MovieDbContext : DbContext
    {


        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<LsMessage> LsMessages { get; set; }
    }
}
