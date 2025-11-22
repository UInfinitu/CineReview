using CineReview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        static List<Serie> series = new List<Serie>()
        {
            new Serie(){ Id=1, Name="serie1", Synopsis="a", Director="Christopher Nolan", ReleaseYear=2011},
            new Serie(){ Id=2, Name="serie2", Synopsis="b", Director="The Wachowskis", ReleaseYear=2012},
            new Serie(){ Id=3, Name="serie3", Synopsis="c", Director="Christopher Nolan", ReleaseYear=2013}
        };
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(series);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = series.Find(x => x.Id == id);
            if (movie == null)
            {
                //return NotFound();
                return NotFound(new { Message = $"Série com Id={id} não encontrada." });
            }
            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] Serie newSeries)
        {
            if (newSeries == null)
                return BadRequest("O corpo da requisição é inválido.");

            if (series.Any(x => x.Id == newSeries.Id))
                return Conflict(new { Message = $"Já existe uma série com Id={newSeries.Id}." });

            series.Add(newSeries);
            return CreatedAtAction(nameof(Get), new { id = newSeries.Id }, newSeries);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Serie updatedSeries)
        {
            if (updatedSeries == null)
                return BadRequest("O corpo da requisição é inválido.");

            var existing = series.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                return NotFound(new { Message = $"Série com Id={id} não encontrada." });

            // Atualiza o objeto existente (mantém o Id)
            existing.Name = updatedSeries.Name;
            existing.Synopsis = updatedSeries.Synopsis;
            existing.Director = updatedSeries.Director;
            existing.ReleaseYear = updatedSeries.ReleaseYear;
            existing.Seasons = updatedSeries.Seasons;

            return Ok(new
            {
                Message = "Série atualizada com sucesso.",
                Updated = existing
            });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var serie = series.FirstOrDefault(x => x.Id == id);
            if (serie == null)
                return NotFound(new { Message = $"Série com Id={id} não encontrada." });

            series.Remove(serie);
            return Ok(new { Message = $"Série '{serie.Name}' removida com sucesso." });
        }
    }
}
