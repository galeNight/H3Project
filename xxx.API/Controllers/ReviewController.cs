using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;
using xxx.Repository.Repositories;

namespace xxx.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _Repo;
        public ReviewController(IReviewRepository repo)
        {
            _Repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _Repo.GetAllReviews();
            return Ok(reviews);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if(review == null)
            {
                return BadRequest("review is null");
            }

            var newReview = await _Repo.CreateReview(review);
            return CreatedAtAction(nameof(GetAllReviews), new { id = newReview.Id });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>DeleteReview(int id)
        {
            var isDeleted = await _Repo.DeleteReview(id);
            if (isDeleted)
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
