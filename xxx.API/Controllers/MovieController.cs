using Microsoft.AspNetCore.Mvc;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;
using xxx.Repository.Repositories;

namespace xxx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository repo;

        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await repo.GetAllMovies();

            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var foundMovie = await repo.GetMovieById(id);

            if (foundMovie == null)
            {
                return NotFound();
            }

            return Ok(foundMovie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie is null.");
            }
            var newMovieCreated = await repo.CreateMovie(movie);
            // Return the newly created move
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByid(int id)
        {
            var isDeleted = await repo.DeleteById(id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("Movie ID mismatch.");
            }
            try
            {
                var updatedMovie = await repo.UpdateMovie(movie);
                return Ok(updatedMovie);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
