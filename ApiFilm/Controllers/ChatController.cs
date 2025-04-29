using ApiFilm.DataBaseContext;
using ApiFilm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO; // Добавьте эту строку
using System.Net.Http;

namespace ApiFilm.Controllers
{
    // Controllers/ChatController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public ChatController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _context.Messages.ToList();
            return Ok(movies);
        }

        // Получение всех сообщений для фильма
        [HttpGet("movie/{movieId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByMovie(int movieId)
        {
            var messages = await _context.Messages.Where(m => m.MovieId == movieId)
                .ToListAsync();
            return Ok(messages);
        }

        // Отправка нового сообщения
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage([FromBody] Message message)
        {
            if (message == null) return BadRequest();

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMessagesByMovie), new { movieId = message.MovieId }, message);
        }

        [HttpGet("lsMessage")]
        public IActionResult GetLsMessage()
        {
            var movies = _context.LsMessages.ToList();
            return Ok(movies);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMes(int id)
        {
            var mes = await _context.Messages.FindAsync(id);
            if (mes == null)
            { 
                return BadRequest();
            }
            _context.Messages.Remove(mes);
            await _context.SaveChangesAsync();
            return Ok(mes);
        }

        // Отправка нового сообщения
        [HttpPost("lsMes")]
        public async Task<ActionResult<LsMessage>> PostLsMessage([FromBody] LsMessage message)
        {
            if (message == null) return BadRequest();

            _context.LsMessages.Add(message);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLsMessage), new { Id = message.Id }, message);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMes(int id, [FromBody] Message updatedMes)
        {
            var mes = _context.Messages.FirstOrDefault(m => m.Id == id);
            if (mes == null)
            {
                return NotFound();
            }

            mes.Id = mes.Id;
            mes.Content = updatedMes.Content;
            mes.UserId = mes.UserId;
            mes.MovieId = mes.MovieId;
            mes.CreatedAt = mes.CreatedAt;
            mes.Url = updatedMes.Url;
            _context.SaveChanges();
            

            return NoContent();
        }

        [HttpDelete("Mes/{id}")]
        public async Task<IActionResult> DeleteLsMes(int id)
        {
            var mes = await _context.LsMessages.FindAsync(id);
            if (mes == null)
            {
                return BadRequest();
            }
            _context.LsMessages.Remove(mes);
            await _context.SaveChangesAsync();
            return Ok(mes);
        }

        [HttpPut("LsMes/{id}")]
        public IActionResult UpdateLsMes(int id, [FromBody] LsMessage updatedMes)
        {
            var mes = _context.LsMessages.FirstOrDefault(m => m.Id == id);
            if (mes == null)
            {
                return NotFound();
            }

            mes.Id = mes.Id;
            mes.Content = updatedMes.Content;
            mes.UserId1 = mes.UserId1;
            mes.UserId2 = mes.UserId2;
            mes.CreatedAt = mes.CreatedAt;
            mes.Url = updatedMes.Url;
            _context.SaveChanges();


            return NoContent();
        }

    }
}
