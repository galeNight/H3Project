using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xxx.Repository.Interfaces;
using xxx.Repository.Models;

namespace xxx.Repository.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _Context;
        public ReviewRepository(DataContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _Context.Reviews.ToListAsync();
        }
        public async Task<Review> GetReviewById(int id)
        {
            var foundReview = await _Context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            return foundReview ?? throw new KeyNotFoundException($"Review with id {id} not found.");
        }
        public async Task<Review> CreateReview(Review review)
        {
            _Context.Reviews.Add(review);
            await _Context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> DeleteReview(int id)
        {
            var review = await _Context.Reviews.SingleOrDefaultAsync(x => x.Id == id);
            if (review != null)
            {
                _Context.Reviews.Remove(review);
                await _Context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
