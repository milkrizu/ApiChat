using ApiFilm.Interfaces;
using ApiFilm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilm.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }


        [HttpGet("titles/{title}")]
        public IActionResult GetMovieTitle(string title)
        {
            var movie = _movieService.GetMovieByTitle(title);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if (movie == null || string.IsNullOrEmpty(movie.Title))
            {
                return BadRequest("Invalid movie data.");
            }

            var addedMovie = _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = addedMovie.Id }, addedMovie);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var movie = _movieService.UpdateMovie(id, updatedMovie);
            if (movie == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
    }
}
