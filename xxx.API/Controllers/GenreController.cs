using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;
using xxx.Repository.Repositories;

namespace xxx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repo;

        public GenreController(IGenreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _repo.GetAllGenres();
            return Ok(genres);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGrenreById(int id)
        {
            var foundGrenre = await _repo.GetGrenreById(id);
            return Ok(foundGrenre);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGrenre([FromBody] Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre is null");
            }
            var newGenre = await _repo.CreateGenre(genre);
            return CreatedAtAction(nameof(GetAllGenres), new { id = genre.Id }, genre);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>DeleteGenre(int id)
        {
            var isdeleted = await _repo.DeleteGenre(id);
            if (isdeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
