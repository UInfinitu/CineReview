using CineReview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@test.com", Password = "password1" },
        };

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user == null)
            {
                //return NotFound();
                return NotFound(new { Message = $"Tarefa com Id={id} não encontrada." });
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User newUser)
        {
            if (newUser == null)
                return BadRequest("O corpo da requisição é inválido.");

            if (users.Any(x => x.Id == newUser.Id))
                return Conflict(new { Message = $"Já existe um usuário com Id={newUser.Id}." });

            users.Add(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null)
                return BadRequest("O corpo da requisição é inválido.");

            var existing = users.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                return NotFound(new { Message = $"Usuário com Id={id} não encontrado." });

            // Atualiza o objeto existente (mantém o Id)
            existing.Name = updatedUser.Name;
            existing.Email = updatedUser.Email;
            existing.Password = updatedUser.Password;

            return Ok(new
            {
                Message = "Usuário atualizado com sucesso.",
                Updated = existing
            });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound(new { Message = $"Usuário com Id={id} não encontrado." });

            users.Remove(user);
            return Ok(new { Message = $"Usuário '{user.Name}' removido com sucesso." });
        }
    }
}