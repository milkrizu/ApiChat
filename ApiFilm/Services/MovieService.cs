using ApiFilm.DataBaseContext;
using ApiFilm.Interfaces;
using ApiFilm.Models;

namespace ApiFilm.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movie.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movie.FirstOrDefault(m => m.Id == id);
        }
        
        public Movie GetMovieByTitle(string title)
        {
            return _context.Movie.FirstOrDefault(m => m.Title == title);
        }


        public Movie AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;

            movie.Title = updatedMovie.Title;
            movie.Description = updatedMovie.Description;
            movie.Genre = updatedMovie.Genre;
            movie.ReleaseDate = updatedMovie.ReleaseDate;
            movie.Rating = updatedMovie.Rating;
            movie.ImageUrl = updatedMovie.ImageUrl;
            _context.SaveChanges();
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
