using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;
using xxx.Repository.Repositories;

namespace xxx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _repo;
        public DirectorController(IDirectorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            var directors = await _repo.GetAllDirectors();
            return Ok(directors);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDirectorById(int id)
        {
            var foundDirector = await _repo.GetDirectorById(id);
            return Ok(foundDirector);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDirector([FromBody]Director director)
        {
            if(director == null)
            {
                return BadRequest("Director is null");
            }
            var newDirector = await _repo.CreateDirector(director);
            return CreatedAtAction(nameof(GetAllDirectors),new { id = director.Id },director);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>DeleteDirector(int id)
        {
            var isDeleted = await _repo.DeleteDirector(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
