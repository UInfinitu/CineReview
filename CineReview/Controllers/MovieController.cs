using CineReview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        static List<Movie> movies = new List<Movie>()
        {
            new Movie(){ Id=1, Name="Inception", Synopsis="a", Director="Christopher Nolan", ReleaseYear=2011, Duration= 210},
            new Movie(){ Id=2, Name="The Matrix", Synopsis="b", Director="The Wachowskis", ReleaseYear=2012, Duration = 211},
            new Movie(){ Id=3, Name="Interstellar", Synopsis="c", Director="Christopher Nolan", ReleaseYear = 2013, Duration = 212}
        };
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(movies);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = movies.Find(x => x.Id == id);
            if (movie == null)
            {
                //return NotFound();
                return NotFound(new { Message = $"Filme com Id={id} não encontrado." });
            }
            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie newMovie)
        {
            if (newMovie == null)
                return BadRequest("O corpo da requisição é inválido.");

            if (movies.Any(x => x.Id == newMovie.Id))
                return Conflict(new { Message = $"Já existe um filme com Id={newMovie.Id}." });

            movies.Add(newMovie);
            return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie updatedMovie)
        {
            if (updatedMovie == null)
                return BadRequest("O corpo da requisição é inválido.");

            var existing = movies.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                return NotFound(new { Message = $"Filme com Id={id} não encontrado." });

            // Atualiza o objeto existente (mantém o Id)
            existing.Name = updatedMovie.Name;
            existing.Synopsis = updatedMovie.Synopsis;
            existing.Director = updatedMovie.Director;
            existing.ReleaseYear = updatedMovie.ReleaseYear;
            existing.Duration = updatedMovie.Duration;

            return Ok(new
            {
                Message = "Filme atualizado com sucesso.",
                Updated = existing
            });
        } 

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound(new { Message = $"Filme com Id={id} não encontrado." });

            movies.Remove(movie);
            return Ok(new { Message = $"Filme '{movie.Name}' removido com sucesso." });
        }
    }
}
